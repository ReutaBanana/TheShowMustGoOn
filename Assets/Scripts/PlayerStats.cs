using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float famePoints;
    private float currentMoney;
    private int currentFailPoints;
    private int currentHealthDecrease;
    private int healthAmount=3;

    [SerializeField] private float ticketPrice =5;
    [SerializeField] private float famePerShow =6;

    [SerializeField] SimonGame currentGame;
    [SerializeField] GameConstructor gameMananger;

    public event Action<string, int> onHealthChange;

    void Start()
    {
        currentGame.onEndGameCondition += AddFailPoints;
        gameMananger.onShowEnd += EndOfTheShowCalculation;
    }
    public void AddHealthAmount()
    {
        healthAmount += 1;
        onHealthChange?.Invoke("Win", healthAmount);
    }

    private void Update()
    {
        
    }
    private void AddFailPoints(string condition)
    {
        if (condition == "Lose")
        {
            currentFailPoints += 1;
            currentHealthDecrease += 1;
            onHealthChange?.Invoke("Lose",currentHealthDecrease);
        }
    }

    public void MoneyCalculation()
    {
        currentMoney+= famePoints * ticketPrice;
        if (currentMoney < 0)
            currentMoney = 0;
    }    
    public void FamePointsCalculation()
    {
        if (currentFailPoints == 0)
            famePoints += famePerShow;
        else
        {
            famePoints += famePerShow;
            famePoints -= currentFailPoints * 0.5f;

        }
    }
    public void EndOfTheShowCalculation()
    {
        FamePointsCalculation();
        MoneyCalculation();
        currentFailPoints = 0;
    }
    public float GetFamePoints()
    {
        return famePoints;
    }public float GetMoney()
    {
        return currentMoney;
    }
    public void SpendMoney(float amount)
    {
        currentMoney -= amount;
    }
    public void addFamePoints(float amount)
    {
        famePoints += amount;
    }

}
