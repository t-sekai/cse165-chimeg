using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodTestAttach : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] NeedleAttach needleAttach;
    [SerializeField] private GameObject stepPage;
    [SerializeField] private GameObject result1;
    [SerializeField] private UIStep step;

    bool touchedFinger = false;
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
        if (other.tag == "BloodTestArea" && needleAttach.touchedFinger)
        {
            touchedFinger = true;
            Destroy(needleAttach.droplet);
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
        step.incrementStep();
        stepPage.SetActive(false);
        result1.SetActive(true);
    }
}
