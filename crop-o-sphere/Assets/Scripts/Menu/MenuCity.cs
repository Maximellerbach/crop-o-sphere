using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCity : MonoBehaviour
{
    public City city;
    public GameObject[] news;
    public GameObject[] advertisings;
    public GameObject[] goMissions;

    public void SetCity(City _city)
    {
        city = _city;
        SetMissions();
    }

    void SetMissions()
    {
        foreach (GameObject go in goMissions)
        {
            UpdateMission mission = go.GetComponent<UpdateMission>();
            mission.SetCity(city);
            Debug.Log("Added city to mission");
        }
    }

}
