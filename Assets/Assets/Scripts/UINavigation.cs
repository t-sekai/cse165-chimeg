using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UINavigation : MonoBehaviour
{
    [SerializeField] private GameObject titlePage;
    [SerializeField] private GameObject signInPage;
    [SerializeField] private GameObject homePage;
    [SerializeField] private GameObject info;
    [SerializeField] private GameObject tuyaInterface;
    [SerializeField] private GameObject symptomsInput;
    [SerializeField] private GameObject symptomsFound;
    [SerializeField] private GameObject stepPage;
    [SerializeField] private GameObject result1;
    [SerializeField] private GameObject result2;

    [SerializeField] private GameObject currentPage;
    [SerializeField] private GameObject previousPage;
    [SerializeField] private GameObject nextPage;

    [SerializeField] private GameObject gt1;
    [SerializeField] private GameObject gt2;

    private bool isResultTrue;



    // Start is called before the first frame update
    void Start()
    {
        currentPage = titlePage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void home()
    {
        stepPage.SetActive(false);
        signIn();
    }

    public void titleStart()
    {
        info.SetActive(true);
        titlePage.SetActive(false);
        signInPage.SetActive(true);
        currentPage = signInPage;
        previousPage = titlePage;
        nextPage = homePage;
    }

    public void signIn()
    {
        info.SetActive(true);
        signInPage.SetActive(false);
        homePage.SetActive(true);
        previousPage = currentPage;
        currentPage = nextPage;
        nextPage = tuyaInterface;
    }

    public void tuya()
    {
        info.SetActive(true);
        homePage.SetActive(false);
        tuyaInterface.SetActive(true);
        previousPage = currentPage;
        currentPage = nextPage;
        nextPage = symptomsInput;
    }

    public void provideSymptoms()
    {
        info.SetActive(false);
        tuyaInterface.SetActive(false);
        symptomsInput.SetActive(true);
        currentPage = symptomsInput;
        previousPage = tuyaInterface;
        nextPage = symptomsFound;
    }
    public void provideSymptomsReturn()
    {
        info.SetActive(true);
        symptomsInput.SetActive(false);
        tuyaInterface.SetActive(true);
        currentPage = tuyaInterface;
        previousPage = symptomsInput;
        nextPage = tuyaInterface;
    }

    public void showData()
    {
        if (isResultTrue)
        {
            info.SetActive(false);
            tuyaInterface.SetActive(false);
            result2.SetActive(true);
            currentPage = result2;
            previousPage = tuyaInterface;
            nextPage = result2;
        }
    }

    public void symptomsResult()
    {
        info.SetActive(false);
        symptomsInput.SetActive(false);
        symptomsFound.SetActive(true);
        currentPage = symptomsFound;
        previousPage = tuyaInterface;
        nextPage = stepPage;
    }
    public void steps()
    {
        info.SetActive(false);
        symptomsFound.SetActive(false);
        stepPage.SetActive(true);
        currentPage = stepPage;
        previousPage = tuyaInterface;
        nextPage = stepPage;

        gt1.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        gt1.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
        gt2.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        gt2.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
    }

    public void firstResultNext()
    {
        result1.SetActive(false);
        stepPage.SetActive(true);
        currentPage = stepPage;
        previousPage = result1;
        nextPage = stepPage;
    }

    public void secondResultNext()
    {
        info.SetActive(true);
        result2.SetActive(false);
        tuyaInterface.SetActive(true);
        currentPage = tuyaInterface;
        previousPage = result2;
        nextPage = tuyaInterface;
    }

    public void isResult()
    {
        isResultTrue = true;
    }
    public void emergency()
    {
        previousPage = currentPage;
        currentPage.SetActive(false);
        provideSymptoms();
    }
}
