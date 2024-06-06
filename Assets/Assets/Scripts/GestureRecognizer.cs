using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Management;

[System.Serializable]
public class Gesture
{
    [field: SerializeField]
    public string Name { get; set; }

    [field: SerializeField]
    public float Magnitude { get; private set; }

    [field: SerializeField]
    public float Similarity { get; private set; }

    public UnityEvent<bool> OnRecognized;

    [SerializeField]
    private List<Quaternion> data;

    public List<Quaternion> Data
    {
        get => data;

        set
        {
            data = value;
            float total = 0f;
            foreach (Quaternion d in data)
                total += d.x * d.x + d.y * d.y + d.z * d.z + d.w * d.w;
            Magnitude = Mathf.Sqrt(total);
        }
    }

    public void ComputeSimilarity(IList<Quaternion> other)
    {
        if (data == null || data.Count != other.Count)
        {
            Similarity = 0f;
            return;
        }

        float otherTotal = 0f;
        foreach (Quaternion d in other)
            otherTotal += d.x * d.x + d.y * d.y + d.z * d.z + d.w * d.w;
        float otherMagnitude = Mathf.Sqrt(otherTotal);

        float cosineSimilarity = 0f;
        for (int i = 0; i < other.Count; i++)
            cosineSimilarity += other[i].x * data[i].x + other[i].y * data[i].y + other[i].z * data[i].z + other[i].w * data[i].w;
        cosineSimilarity /= otherMagnitude * Magnitude;

        Similarity = cosineSimilarity * 0.5f + 0.5f;
    }
}

public class GestureRecognizer : MonoBehaviour
{
    enum Hand
    {
        Left,
        Right,
    };

    [SerializeField]
    private Hand handedness;

    [SerializeField]
    private float recognizeThreshold = 0.9f;

    [SerializeField]
    private List<Gesture> gestures;

    [SerializeField]
    private bool isSaving = false;

    private Gesture previousGesture = null;
    private Dictionary<string, Gesture> gestureNames = new Dictionary<string, Gesture>();

    private XRHandSubsystem subsystem;

    void Start()
    {
        subsystem = XRGeneralSettings.Instance?.Manager?.activeLoader?.GetLoadedSubsystem<XRHandSubsystem>();

        foreach (var gesture in gestures)
            gestureNames.Add(gesture.Name, gesture);
    }

    public XRHand GetHand()
    {
        return handedness == Hand.Left ? subsystem.leftHand : subsystem.rightHand; ;
    }

    public UnityEvent<bool> GetRecognizedEvent(string gestureName)
    {
        if (!gestureNames.ContainsKey(gestureName))
            return null;

        return gestureNames[gestureName].OnRecognized;
    }

    public float GetSimilarity(string gestureName, float threshold)
    {
        var hand = GetHand();

        if (!hand.isTracked || !gestureNames.ContainsKey(gestureName))
            return 0f;

        return Mathf.Clamp01((gestureNames[gestureName].Similarity - threshold) / (1f - threshold));
    }

    public Vector3 GetJointPosition(int joint)
    {
        var hand = GetHand();

        int count = XRHandJointID.EndMarker.ToIndex() - XRHandJointID.BeginMarker.ToIndex();
        hand.GetJoint(XRHandJointIDUtility.FromIndex(joint % count)).TryGetPose(out var pose);
        return pose.position;
    }

    public Quaternion GetJointRotation(int joint)
    {
        var hand = GetHand();

        int count = XRHandJointID.EndMarker.ToIndex() - XRHandJointID.BeginMarker.ToIndex();
        hand.GetJoint(XRHandJointIDUtility.FromIndex(joint % count)).TryGetPose(out var pose);
        return pose.rotation;
    }

    void Update()
    {
        var hand = GetHand();

        if (!hand.isTracked)
        {
            if (previousGesture != null)
                previousGesture.OnRecognized?.Invoke(false);
            previousGesture = null;
            return;
        }

        var data = new List<Quaternion>();
        for (int i = XRHandJointID.BeginMarker.ToIndex(); i < XRHandJointID.EndMarker.ToIndex(); i++)
        {
            var joint = hand.GetJoint(XRHandJointIDUtility.FromIndex(i));
            joint.TryGetPose(out var pose);
            data.Add(Quaternion.Inverse(hand.rootPose.rotation) * pose.rotation);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isSaving)
        {
            var gesture = new Gesture();
            gesture.Data = data;
            gestures.Add(gesture);
        }

        float maxSimilarity = 0f;
        Gesture maxGesture = null;
        foreach (Gesture g in gestures)
        {
            g.ComputeSimilarity(data);
            if (g.Similarity > maxSimilarity)
            {
                maxSimilarity = g.Similarity;
                maxGesture = g;
            }
        }

        var oldGesture = previousGesture;

        if (maxSimilarity > recognizeThreshold)
        {
            if (previousGesture != maxGesture)
            {
                if (previousGesture != null)
                    previousGesture.OnRecognized?.Invoke(false);
                maxGesture.OnRecognized?.Invoke(true);
            }
            previousGesture = maxGesture;
        }
        else
        {
            if (previousGesture != null)
                previousGesture.OnRecognized?.Invoke(false);
            previousGesture = null;
        }

        if (previousGesture != oldGesture)
            Debug.Log("Gesture recognized: " + (previousGesture?.Name ?? "null"));
    }
}
