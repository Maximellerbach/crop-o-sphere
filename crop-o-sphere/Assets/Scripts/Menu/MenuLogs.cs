using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLogs : MonoBehaviour
{
    public LogsHandler logsHandler;
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
        if (text == null) { Debug.Log("couldn't find text component"); }
    }

    void SetLogs()
    {
        if (text == null) { return; }

        // UpdateMission mission = go.GetComponent<L>();
        // mission.SetCity(city);
        // Debug.Log("Added city to mission");
    }

}
