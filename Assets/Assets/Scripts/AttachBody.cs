using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachBody : MonoBehaviour
{
    [SerializeField] Controls rightControl;
    [SerializeField] Controls leftControl;
    private bool inArea = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inArea && rightControl.selectedObject != this.gameObject && leftControl.selectedObject != this.gameObject)
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            inArea = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            inArea = false;
        }
    }
}
