using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSystem : MonoBehaviour
{
    private int flayersPoints=0;
    private int[] moneyPerFlayer = new int[] { 20, 80, 130 };
    private int improvisationSkillPoints=0;
    private int[] moneyPerImprovistation = new int[] { 35, 60, 120 };
    [SerializeField] PlayerStats stats;

    public event Action<string,float> onPowerupChange;
    public event Action<string> onDisableButtonEvent;

    // Update is called once per frame

    public void BuyFlyers()
    {
        if(flayersPoints<3&&stats.GetMoney()- moneyPerFlayer[flayersPoints] >= 0)
        {
            stats.addFamePoints(10);
            stats.SpendMoney(moneyPerFlayer[flayersPoints]);
            flayersPoints++;
            if(flayersPoints==3)
            {
                onPowerupChange?.Invoke("Flayer", 404);

            }
            else
            {
                onPowerupChange?.Invoke("Flayer", moneyPerFlayer[flayersPoints]);

            }

            stats.checkfamePointSkill();
        }
        else if ( flayersPoints>3)
        {
            Debug.Log("No more availble points");
        }
        else
        { Debug.Log("not enough money"); }
    }
    public void BuyImprovistionSkill()
    {
        if(improvisationSkillPoints<3 && stats.GetMoney()- moneyPerImprovistation[improvisationSkillPoints] >= 0)
        {
            stats.AddHealthAmount();
            stats.SpendMoney(moneyPerImprovistation[improvisationSkillPoints]);

            improvisationSkillPoints++;
            if(improvisationSkillPoints==3)
            {

                onPowerupChange?.Invoke("Improvistation", moneyPerImprovistation[2]);

            }
            else
                onPowerupChange?.Invoke("Improvistation", moneyPerImprovistation[improvisationSkillPoints]);

        }
        else if (improvisationSkillPoints > 3)
        {

            Debug.Log("No more availble points");
        }
        else 
        { Debug.Log("not enough money"); }
    }

    private void Update()
    {
        if(improvisationSkillPoints==3)
        {
            onDisableButtonEvent?.Invoke("Improvisation");
        }
        if(flayersPoints==3)
        {
            onDisableButtonEvent?.Invoke("Flyer");

        }
    }
}
