using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSystem : MonoBehaviour
{
    private int flayersPoints=1;
    private int[] moneyPerFlayer = new int[] { 10, 50, 70 };
    private int costumesPoints=1;
    private int[] moneyPerCostume = new int[] { 15, 30, 100 };
    private int improvisationSkillPoints=1;
    private int[] moneyPerImprovistation = new int[] { 10, 50, 70 };
    [SerializeField] PlayerStats stats;

    public event Action<string,float> onPowerupChange;

    // Update is called once per frame

    public void BuyFlyers()
    {
        if(flayersPoints<=3&&stats.GetMoney()> moneyPerFlayer[flayersPoints - 1])
        {
            stats.addFamePoints(10);
            stats.SpendMoney(moneyPerImprovistation[improvisationSkillPoints - 1]);
            flayersPoints++;
            stats.checkfamePointSkill();
            onPowerupChange?.Invoke("Flayer",moneyPerFlayer[flayersPoints - 1]);
        }
    }
    public void BuyCostumes()
    {
        
    }
    public void BuyImprovistionSkill()
    {
        if(improvisationSkillPoints<=3 && stats.GetMoney()> moneyPerImprovistation[improvisationSkillPoints - 1])
        {
            stats.AddHealthAmount();
            stats.SpendMoney(moneyPerImprovistation[improvisationSkillPoints - 1]);
            improvisationSkillPoints++;
            onPowerupChange?.Invoke("Improvistation", moneyPerImprovistation[improvisationSkillPoints - 1]);

        }
    }
}
