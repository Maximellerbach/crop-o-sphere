using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogsHandler : MonoBehaviour
{
    private string logs;

    void Start()
    {
        logs = "";
    }

    public void Log(string str)
    {
        Debug.Log(str);
        logs += str;
    }

    public string GetLogs()
    {
        return logs;
    }
}
