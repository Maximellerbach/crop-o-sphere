using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalState
{
    public static int baseMoney = 10;
    public static float cycleTime = 180.0f;
    public static float timeGrowWheat = 45.0f;
    public static float timeGrowPotato = 45.0f;

    // tile prices
    public static int tileWheatPrice = 3;
    public static int tilePotatoPrice = 5;
    public static int tileApplePrice = 3;
    public static int tileMeatPrice = 10;

    // sell prices
    public static int wheatPrice = 1;
    public static int potatoPrice = 1;
    public static int applePrice = 2;
    public static int meatPrice = 5;

    // passive consumption
    public static int passiveConsumptionMeat = 1;
    public static int passiveIncome = 5;

    // default values
    public static int wheat = 10;
    public static int potato = 10;
    public static int apple = 5;
    public static int meat = 3;

}
