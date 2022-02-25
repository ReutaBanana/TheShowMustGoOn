using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSystem : MonoBehaviour
{
    private int flayersPoints=1;
    private float[] moneyPerFlayer = new float[] { 10, 50, 70 };
    private int costumesPoints=1;
    private float[] moneyPerCostume = new float[] { 15, 30, 100 };
    private int improvisationSkillPoints=1;
    private float[] moneyPerImprovistation = new float[] { 10, 50, 70 };
    [SerializeField] PlayerStats stats;

    public event Action<float> onPricePerFlayerChange;

    // Update is called once per frame

    public void BuyFlyers()
    {
        if(stats.GetMoney()>=moneyPerFlayer[flayersPoints - 1])
        {
            flayersPoints++;
            stats.addFamePoints(10);
            onPricePerFlayerChange?.Invoke(moneyPerFlayer[flayersPoints - 1]);
        }
    }
    public void BuyCostumes()
    {
        
    }
}
