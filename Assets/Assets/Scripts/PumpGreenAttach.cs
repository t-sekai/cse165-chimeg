using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpGreenAttach : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Controls rightControl;
    [SerializeField] Controls leftControl;
    private bool inArea = false;
    [SerializeField] private GameObject greenHighlight;
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
            greenHighlight.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PumpGreenArea")
        {
            inArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PumpGreenArea")
        {
            inArea = false;
        }
    }
}
