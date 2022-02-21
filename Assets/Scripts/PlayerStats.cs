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

    [SerializeField] SimonGame game;
    [SerializeField] SimonLevelConstructor gameMananger;
    // Start is called before the first frame update
    void Start()
    {
        game.onEndGameCondition += AddFailPoints;
        gameMananger.onLevelEnd += EndOfTheShowCalculation;
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
            famePoints -= failPoints*0.5f;
    }
    public void EndOfTheShowCalculation()
    {
        FamePointsCalculation();
        MoneyCalculation();
        failPoints = 0;
    }
}
