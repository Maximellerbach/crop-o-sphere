using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCity : MonoBehaviour
{
    public City city;
    public GameObject news;
    public GameObject mission;
    public GameObject advertising;

    public void SetCity(City _city)
    {
        city = _city;
    }

}
