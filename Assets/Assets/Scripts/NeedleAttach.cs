using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleAttach : MonoBehaviour
{
    // Start is called before the first frame update
    public bool touchedFinger = false;
    void Start()
    {
        touchedFinger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BloodTestArea")
        {
            touchedFinger = true;
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BloodTestArea")
        {
            
        }
    }*/
}
