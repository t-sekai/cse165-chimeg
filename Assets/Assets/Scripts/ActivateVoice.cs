using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.WitAi;
// using UnityEngine.InputSystem;

public class ActivateVoice : MonoBehaviour
{
    [SerializeField]
    private Wit wit;

    [SerializeField]
    public AudioSource VoiceSignal;
    
    // Update is called once per frame
    private void Update()
    {
        if (wit == null) wit = GetComponent<Wit>();
    }

    public void GestureVoice(bool isRecognized)
    {
        // if gesture is done
        // play sound?
        if (isRecognized)
        {
            VoiceSignal.Play();
            WitActivate();
        }
    }

    public void WitActivate()
    {
        wit.ActivateImmediately();
        //wit.Activate("hey man");
        Debug.Log("Activated wit...");    }
}
