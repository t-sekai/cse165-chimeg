using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class Controls : MonoBehaviour
{
    [SerializeField]
    private InputActionReference selectAction;

    [SerializeField]
    private InputActionReference selectPositionAction;

    [SerializeField]
    private InputActionReference selectRotationAction;

    [SerializeField]
    private LayerMask selectableLayers;

    private GameObject hoveredObject = null;
    private GameObject selectedObject = null;

    private Quaternion initialObjectRotation;
    private Quaternion initialSelectRotation;
    private Vector3 initialSelectLocalPosition;

    void Start()
    {
        selectAction.action.started += onSelect;
        selectAction.action.canceled += onUnselect;

        selectAction.action.Enable();
        selectPositionAction.action.Enable();
    }

    private void onSelect(InputAction.CallbackContext context)
    {
        selectedObject = hoveredObject;
        if (selectedObject != null)
        {
            var rb = selectedObject.GetComponent<Rigidbody>();
            rb.GetComponent<Rigidbody>().useGravity = false;
            initialObjectRotation = rb.transform.rotation;
            initialSelectRotation = selectRotationAction.action.ReadValue<Quaternion>();
            initialSelectLocalPosition = rb.transform.InverseTransformPoint(selectPositionAction.action.ReadValue<Vector3>());
        }
    }

    private void onUnselect(InputAction.CallbackContext context)
    {
        if (selectedObject != null)
            selectedObject.GetComponent<Rigidbody>().useGravity = true;

        selectedObject = null;
    }

    void Update()
    {
        var position = selectPositionAction.action.ReadValue<Vector3>();
        var overlapped = Physics.OverlapSphere(position, 0.01f, selectableLayers);

        if (hoveredObject?.GetComponent<Outline>() is Outline outline0)
            outline0.OutlineColor = outline0.OutlineColor.WithAlpha(0f);

        if (selectedObject == null)
            hoveredObject = overlapped.Length > 0 ? overlapped[0].gameObject : null;

        if (hoveredObject?.GetComponent<Outline>() is Outline outline1)
            outline1.OutlineColor = outline1.OutlineColor.WithAlpha(1f);
    }

    private void FixedUpdate()
    {
        if (selectedObject != null)
        {
            var rb = selectedObject.GetComponent<Rigidbody>();
            
            var position = selectPositionAction.action.ReadValue<Vector3>();
            var translate = position - rb.transform.TransformPoint(initialSelectLocalPosition);
            rb.velocity = 15f * translate;

            var rotation = selectRotationAction.action.ReadValue<Quaternion>();
            var rotate = rotation * Quaternion.Inverse(initialSelectRotation) * initialObjectRotation * Quaternion.Inverse(rb.rotation);
            rotate.ToAngleAxis(out float deg, out Vector3 axis);
            rb.angularVelocity = 15f * deg * Mathf.Deg2Rad * axis;
        }
    }
}
