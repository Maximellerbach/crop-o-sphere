using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour, Interactable
{
    public MenuHandler menuHandler;
    public void OnEnterCollideWith()
    {
        menuHandler.OnEnterFarm();
    }
    public void OnExitCollideWith()
    {
        menuHandler.OnEnterFarm();
    }
}
