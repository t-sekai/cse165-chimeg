using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Controls : MonoBehaviour
{
    [Header("Selection")]

    [SerializeField]
    private InputActionReference selectAction;

    [SerializeField]
    private InputActionReference selectPositionAction;

    [SerializeField]
    private InputActionReference selectRotationAction;

    [SerializeField]
    private LayerMask selectableLayers;

    [Header("Teleportation")]

    [SerializeField]
    private InputActionReference headPositionAction;

    [SerializeField]
    private GameObject cameraOffset;

    [SerializeField]
    private LayerMask teleportableLayers;

    [SerializeField]
    private XRRayInteractor rayInteractor;

    private GameObject hoveredObject = null;
    private GameObject selectedObject = null;

    private Quaternion initialObjectRotation;
    private Quaternion initialSelectRotation;
    private Vector3 initialSelectLocalPosition;

    private Vector3? teleportPosition;

    private bool isPointing = false;
    public void OnPoint(bool b) => isPointing = b;

    void Start()
    {
        selectAction.action.started += onSelect;
        selectAction.action.canceled += onUnselect;

        selectAction.action.Enable();
        selectPositionAction.action.Enable();
    }

    private void onSelect(InputAction.CallbackContext context)
    {
        if (!isPointing)
        {
            selectedObject = hoveredObject;
            if (selectedObject != null)
            {
                var rb = selectedObject.GetComponent<Rigidbody>();
                rb.GetComponent<Rigidbody>().useGravity = false;
                initialObjectRotation = rb.transform.rotation;
                initialSelectRotation = selectRotationAction.action.ReadValue<Quaternion>();
                var position = selectPositionAction.action.ReadValue<Vector3>() + cameraOffset.transform.position;
                initialSelectLocalPosition = rb.transform.InverseTransformPoint(position);
            }
        }
        else if (teleportPosition.HasValue)
        {
            var position = teleportPosition.Value - headPositionAction.action.ReadValue<Vector3>();
            position.y = teleportPosition.Value.y;
            cameraOffset.transform.position = position;
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
        var position = selectPositionAction.action.ReadValue<Vector3>() + cameraOffset.transform.position;
        var overlapped = Physics.OverlapSphere(position, 0.01f, selectableLayers);

        if (hoveredObject?.GetComponent<Outline>() is Outline outline0)
            outline0.OutlineColor = outline0.OutlineColor.WithAlpha(0f);

        if (selectedObject == null)
            hoveredObject = overlapped.Length > 0 ? overlapped[0].gameObject : null;

        if (hoveredObject?.GetComponent<Outline>() is Outline outline1)
            outline1.OutlineColor = outline1.OutlineColor.WithAlpha(1f);

        if (isPointing)
        {
            rayInteractor.GetLineOriginAndDirection(out var origin, out var dir);

            rayInteractor.enabled = true;

            Physics.Raycast(origin, dir, out var hit, float.PositiveInfinity, teleportableLayers);
            teleportPosition = hit.transform != null ? origin + hit.distance * dir : null;
        }
        else
        {
            rayInteractor.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        if (selectedObject != null)
        {
            var rb = selectedObject.GetComponent<Rigidbody>();

            var position = selectPositionAction.action.ReadValue<Vector3>() + cameraOffset.transform.position;
            var translate = position - rb.transform.TransformPoint(initialSelectLocalPosition);
            rb.velocity = 15f * translate;

            var rotation = selectRotationAction.action.ReadValue<Quaternion>();
            var rotate = rotation * Quaternion.Inverse(initialSelectRotation) * initialObjectRotation * Quaternion.Inverse(rb.rotation);
            rotate.ToAngleAxis(out float deg, out Vector3 axis);
            rb.angularVelocity = 15f * deg * Mathf.Deg2Rad * axis;
        }
    }
}
