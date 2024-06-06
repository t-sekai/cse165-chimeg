using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class InsulinPumpLine : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> anchors;

    private LineRenderer lineRenderer;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lineRenderer.positionCount = anchors.Count;
        for (int i = 0; i < anchors.Count; i++)
            lineRenderer.SetPosition(i, anchors[i].transform.position);
    }
}
