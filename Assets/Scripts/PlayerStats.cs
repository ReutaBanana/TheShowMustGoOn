using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float famePoints;
    private float currentMoney;
    private float failPoints;

    [SerializeField] private float ticketPrice =5;
    [SerializeField] private float famePerShow =6;

    [SerializeField] SimonGame currentGame;
    [SerializeField] GameConstructor gameMananger;

    void Start()
    {
        currentGame.onEndGameCondition += AddFailPoints;
        gameMananger.onShowEnd += EndOfTheShowCalculation;
    }

    private void AddFailPoints(string condition)
    {
        if (condition == "Lose")
            failPoints += 1;
    }

    public void MoneyCalculation()
    {
        currentMoney+= famePoints * ticketPrice;
        if (currentMoney < 0)
            currentMoney = 0;
    }    
    public void FamePointsCalculation()
    {
        if (failPoints == 0)
            famePoints += famePerShow;
        else
        {
            famePoints += famePerShow;
            famePoints -= failPoints * 0.5f;

        }
    }
    public void EndOfTheShowCalculation()
    {
        FamePointsCalculation();
        MoneyCalculation();
        failPoints = 0;
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
