using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UIStep : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stepTitle;
    [SerializeField] private TextMeshProUGUI subtitle;
    [SerializeField] private TextMeshProUGUI instructions;
    private int stepNumber;

    // Start is called before the first frame update
    void Start()
    {
        stepNumber = 1;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateStep()
    {
        switch (stepNumber)
        {
            case 1:
                stepTitle.text = "Treatment: Step One";
                subtitle.text = "Blood Glucose Test";
                instructions.text = "Take out the blood glucose test kit.";
                break;
            case 2:
                stepTitle.text = "Treatment: Step Two";
                subtitle.text = "Blood Glucose Test";
                instructions.text = "Prick Tuya's finger to draw blood.";
                break;
            case 3:
                stepTitle.text = "Treatment: Step Three";
                subtitle.text = "Blood Glucose Test";
                instructions.text = "Dab the blood droplet onto the test strip in the device.";
                break;
            case 4:
                stepTitle.text = "Treatment: Step Four";
                subtitle.text = "Rehydration";
                instructions.text = "Get a cup of water.";
                break;
            case 5:
                stepTitle.text = "Treatment: Step Five";
                subtitle.text = "Rehydration";
                instructions.text = "Take out the oral rehydration tablet and drop it in the cup of water.";
                break;
            case 6:
                stepTitle.text = "Treatment: Step Six";
                subtitle.text = "Rehydration";
                instructions.text = "Have Tuya drink the entire cup of water.";
                break;
            case 7:
                stepTitle.text = "Treatment: Step Seven";
                subtitle.text = "Continuous Glucose Monitor";
                instructions.text = "Take out the continuous glucose monitor set.";
                break;
            case 8:
                stepTitle.text = "Treatment: Step Eight";
                subtitle.text = "Continuous Glucose Monitor";
                instructions.text = "Take the small circular device and push down on the highlighted location on Tuya's arm.";
                break;
            case 9:
                stepTitle.text = "Treatment: Step Nine";
                subtitle.text = "Artificial Pancreas Insulin Pump";
                instructions.text = "Take out the insulin pump set.";
                break;
            case 10:
                stepTitle.text = "Treatment: Step Ten";
                subtitle.text = "Artificial Pancreas Insulin Pump";
                instructions.text = "Take the smaller circular device and push down on the highlighted location on Tuya's waist.";
                break;
            case 11:
                stepTitle.text = "Treatment: Step Eleven";
                subtitle.text = "Artificial Pancreas Insulin Pump";
                instructions.text = "Take the large rectangular device and clip it to an article of clothing by Tuya's waist. Ensure the tube is not tangled and is secured.";
                break;
            case 12:
                stepTitle.text = "Treatment: Step Twelve";
                subtitle.text = "Artificial Pancreas Insulin Pump";
                instructions.text = "Take the oval-shaped device and push down on the highlighted location on Tuya's waist.";
                break;
            default:
                break;
        }
    }
}
