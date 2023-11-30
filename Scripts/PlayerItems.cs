using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{

    [Header("Amount")]
    public int totalWood;
    public int totalCarrots;
    public float currentWater;
    public int totalFishes;

    [Header("Limits")]
    public float waterLimit = 50;
    public float carrotsLimit = 15;
    public float woodLimit = 15;
    public float fishesLimit = 5;

    public void WaterLimit(float water)
    {
        if (currentWater < waterLimit)
        {
        currentWater += water;
        }
    }


}
