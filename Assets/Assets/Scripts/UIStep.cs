using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class UIStep : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stepTitle;
    [SerializeField] private TextMeshProUGUI subtitle;
    [SerializeField] private TextMeshProUGUI instructions;

    [SerializeField] private GameObject result1;
    [SerializeField] private GameObject result2;
    [SerializeField] private TextMeshProUGUI resultTime;

    [SerializeField] private GameObject purpleHighlight;
    [SerializeField] private GameObject redHighlight;
    [SerializeField] private GameObject blueHighlight;
    [SerializeField] private GameObject greenHighlight;

    [SerializeField] private GameObject gt1;
    [SerializeField] private GameObject gt2;

    [SerializeField] private GameObject wt1;
    [SerializeField] private GameObject wt2;

    [SerializeField] private GameObject gm1;
    [SerializeField] private GameObject gm2;

    [SerializeField] private GameObject ip1;
    [SerializeField] private GameObject ip2;
    [SerializeField] private GameObject ip3;

    public int stepNumber;

    // Start is called before the first frame update
    void Start()
    {
        stepNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementStep()
    {
        stepNumber++;

        switch (stepNumber)
        {
            case 1:
                stepTitle.text = "Treatment: Step One";
                subtitle.text = "Blood Glucose Test";
                instructions.text = "Take out the blood glucose test kit.";
                gt1.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                gt1.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                gt2.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                gt2.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                break;
            case 2:
                gt2.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                gt1.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                gt1.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                stepTitle.text = "Treatment: Step Two";
                subtitle.text = "Blood Glucose Test";
                instructions.text = "Prick Tuya's finger at the purple highlighted location to draw blood.";
                purpleHighlight.SetActive(true);
                break;
            case 3:
                wt1.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                gt1.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                gt2.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                gt2.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                stepTitle.text = "Treatment: Step Three";
                subtitle.text = "Blood Glucose Test";
                instructions.text = "Dab the blood droplet onto the test strip in the device. Wait for result screen to pop up once completed.";
                break;
            case 4:
                wt2.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                gt2.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                wt1.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                wt1.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                stepTitle.text = "Treatment: Step Four";
                subtitle.text = "Rehydration";
                instructions.text = "Get a cup of water.";
                break;
            case 5:
                wt1.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                wt2.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                wt2.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                stepTitle.text = "Treatment: Step Five";
                subtitle.text = "Rehydration";
                instructions.text = "Take out the oral rehydration tablet and drop it in the cup of water.";
                break;
            case 6:
                gm1.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                gm2.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                wt1.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                wt1.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                stepTitle.text = "Treatment: Step Six";
                subtitle.text = "Rehydration";
                instructions.text = "Have Tuya drink the entire cup of water.";
                break;
            case 7:
                wt1.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                gm1.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                gm1.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                gm2.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                gm2.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                stepTitle.text = "Treatment: Step Seven";
                subtitle.text = "Continuous Glucose Monitor";
                instructions.text = "Take out the continuous glucose monitor set.";
                break;
            case 8:
                ip1.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                ip2.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                ip3.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                gm1.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                gm2.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                gm2.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                stepTitle.text = "Treatment: Step Eight";
                subtitle.text = "Continuous Glucose Monitor";
                instructions.text = "Take the small circular device and push down on the red highlighted location on Tuya's arm.";
                redHighlight.SetActive(true);
                break;
            case 9:
                gm2.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                ip1.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                ip1.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                ip2.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                ip2.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                ip3.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                ip3.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                stepTitle.text = "Treatment: Step Nine";
                subtitle.text = "Artificial Pancreas Insulin Pump";
                instructions.text = "Take out the insulin pump set.";
                break;
            case 10:
                ip1.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                ip3.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                ip2.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                ip2.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                stepTitle.text = "Treatment: Step Ten";
                subtitle.text = "Artificial Pancreas Insulin Pump";
                instructions.text = "Take the smaller circular device and push down on the blue highlighted location on Tuya's waist.";
                blueHighlight.SetActive(true);
                break;
            case 11:
                ip3.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                ip2.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                ip1.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                ip1.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                stepTitle.text = "Treatment: Step Eleven";
                subtitle.text = "Artificial Pancreas Insulin Pump";
                instructions.text = "Take the large rectangular device and clip it to an article of clothing by Tuya's waist. Ensure the tube is not tangled and is secured.";
                break;
            case 12:
                ip1.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                ip3.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                ip3.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                stepTitle.text = "Treatment: Step Twelve";
                subtitle.text = "Artificial Pancreas Insulin Pump";
                instructions.text = "Take the oval-shaped device and push down on the green highlighted location on Tuya's waist.";
                greenHighlight.SetActive(true);
                break;
            default:
                ip3.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                this.gameObject.SetActive(false);
                result2.SetActive(true);
                resultTime.text = System.DateTime.Now.ToString();
                break;
        }
    }

    public void decrementStep()
    {
        if (stepNumber == 1)
        {
            return;
        }
        stepNumber--;

        switch (stepNumber)
        {
            case 1:
                stepTitle.text = "Treatment: Step One";
                subtitle.text = "Blood Glucose Test";
                instructions.text = "Take out the blood glucose test kit.";
                gt1.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                gt1.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                gt2.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                gt2.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                break;
            case 2:
                gt2.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                gt1.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                gt1.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                stepTitle.text = "Treatment: Step Two";
                subtitle.text = "Blood Glucose Test";
                instructions.text = "Prick Tuya's finger at the purple highlighted location to draw blood.";
                purpleHighlight.SetActive(true);
                break;
            case 3:
                wt1.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                gt1.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                gt2.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                gt2.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                stepTitle.text = "Treatment: Step Three";
                subtitle.text = "Blood Glucose Test";
                instructions.text = "Dab the blood droplet onto the test strip in the device. Wait for result screen to pop up once completed.";
                break;
            case 4:
                wt2.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                gt2.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                wt1.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                wt1.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                stepTitle.text = "Treatment: Step Four";
                subtitle.text = "Rehydration";
                instructions.text = "Get a cup of water.";
                break;
            case 5:
                wt1.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                wt2.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                wt2.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                stepTitle.text = "Treatment: Step Five";
                subtitle.text = "Rehydration";
                instructions.text = "Take out the oral rehydration tablet and drop it in the cup of water.";
                break;
            case 6:
                gm1.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                gm2.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                wt1.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                wt1.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                stepTitle.text = "Treatment: Step Six";
                subtitle.text = "Rehydration";
                instructions.text = "Have Tuya drink the entire cup of water.";
                break;
            case 7:
                wt1.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                gm1.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                gm1.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                gm2.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                gm2.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                stepTitle.text = "Treatment: Step Seven";
                subtitle.text = "Continuous Glucose Monitor";
                instructions.text = "Take out the continuous glucose monitor set.";
                break;
            case 8:
                ip1.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                ip2.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                ip3.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                gm1.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                gm2.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                gm2.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                stepTitle.text = "Treatment: Step Eight";
                subtitle.text = "Continuous Glucose Monitor";
                instructions.text = "Take the small circular device and push down on the red highlighted location on Tuya's arm.";
                redHighlight.SetActive(true);
                break;
            case 9:
                gm2.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                ip1.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                ip1.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                ip2.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                ip2.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                ip3.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                ip3.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                stepTitle.text = "Treatment: Step Nine";
                subtitle.text = "Artificial Pancreas Insulin Pump";
                instructions.text = "Take out the insulin pump set.";
                break;
            case 10:
                ip1.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                ip3.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                ip2.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                ip2.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                stepTitle.text = "Treatment: Step Ten";
                subtitle.text = "Artificial Pancreas Insulin Pump";
                instructions.text = "Take the smaller circular device and push down on the blue highlighted location on Tuya's waist.";
                blueHighlight.SetActive(true);
                break;
            case 11:
                ip3.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                ip2.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                ip1.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                ip1.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                stepTitle.text = "Treatment: Step Eleven";
                subtitle.text = "Artificial Pancreas Insulin Pump";
                instructions.text = "Take the large rectangular device and clip it to an article of clothing by Tuya's waist. Ensure the tube is not tangled and is secured.";
                break;
            case 12:
                ip1.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                ip3.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                ip3.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
                stepTitle.text = "Treatment: Step Twelve";
                subtitle.text = "Artificial Pancreas Insulin Pump";
                instructions.text = "Take the oval-shaped device and push down on the green highlighted location on Tuya's waist.";
                greenHighlight.SetActive(true);
                break;
            default:
                ip3.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
                this.gameObject.SetActive(false);
                result2.SetActive(true);
                resultTime.text = System.DateTime.Now.ToString();
                break;
        }
    }
}
