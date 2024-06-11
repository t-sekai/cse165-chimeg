using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Controls rightControl;
    [SerializeField] Controls leftControl;
    private bool inArea = false;
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
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "GlucoseMonitorArea")
        {
            inArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "GlucoseMonitorArea")
        {
            inArea = false;
        }
    }
}
