using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UINavigation : MonoBehaviour
{
    [SerializeField] private GameObject titlePage;
    [SerializeField] private GameObject signInPage;
    [SerializeField] private GameObject homePage;

    [SerializeField] private GameObject tuyaInterface;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TitleStart()
    {
        titlePage.SetActive(false);
        signInPage.SetActive(true);
    }

    public void signIn()
    {
        signInPage.SetActive(false);
        homePage.SetActive(true);
    }

    public void tuya()
    {
        tuyaInterface.SetActive(true);
        homePage.SetActive(false);
    }
}
