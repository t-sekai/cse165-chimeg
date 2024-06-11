using Meta.WitAi;
using Meta.WitAi.CallbackHandlers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AilaControls : MonoBehaviour
{
    [SerializeField] GameObject AilaUI;
    // [SerializeField] string[] ailaComm;

    public void AilaCommand(string[] values)
    {
        bool visibility = true;

        // "open" is the default; if there were more ___ aila commands, would need to add all

        if (values[0] == "close")
            visibility = false;

        AilaUI.SetActive(visibility);

        Debug.Log("COMMAND RECEIVED; VISIBILITY: " + values[0]);

    }

    public void NothingDetected()
    {
        Debug.Log("Nothing happened idioot");
    }

    private void Update()
    {
        // witResponse["entities"]["aila_status:aila_status"][0]["value"].Value;
    }
}
