using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleAttach : MonoBehaviour
{
    // Start is called before the first frame update
    public bool touchedFinger = false;
    public GameObject blood;
    public GameObject droplet;
    [SerializeField] private GameObject purpleHighlight;

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
            droplet = Instantiate(blood, purpleHighlight.transform.position, Quaternion.identity);
            purpleHighlight.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BloodTestArea")
        {
            
        }
    }*/
}
