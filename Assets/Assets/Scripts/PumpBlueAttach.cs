using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpBlueAttach : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Controls rightControl;
    [SerializeField] Controls leftControl;
    private bool inArea = false;
    [SerializeField] private GameObject blueHighlight;
    void Start()
    {
        inArea = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inArea && rightControl.selectedObject != this.gameObject && leftControl.selectedObject != this.gameObject)
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            blueHighlight.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PumpBlueArea")
        {
            inArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PumpBlueArea")
        {
            inArea = false;
        }
    }
}
