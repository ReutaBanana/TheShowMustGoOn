using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int famePoints;
    private int currentMoney;
    private int currentFailPoints;
    private int currentHealthDecrease;
    private int healthAmount=3;
    private int currentHealth = 3;
    private int famePointLevel=1;

    [SerializeField] private int ticketPrice = 5;
    [SerializeField] private int famePerShow = 30;

    [SerializeField] SimonGame currentGame;
    [SerializeField] GameConstructor gameMananger;

    public event Action<string, int> onHealthChange;
    public event Action<int> onFamePointSkillChange;

    void Start()
    {
        currentGame.onEndGameCondition += AddFailPoints;
        gameMananger.onShowEnd += EndOfTheShowCalculation;
    }
    public void AddHealthAmount()
    {
        healthAmount += 1;
        currentHealth++;
        onHealthChange?.Invoke("Win", healthAmount);
    }

    private void Update()
    {
        if(currentHealth<=0)
        {
            Debug.Log("end game State");
        }

    }
    private void AddFailPoints(string condition)
    {
        if (condition == "Lose")
        {
            currentHealth--;
            currentFailPoints += 1;
            currentHealthDecrease += 1;
            onHealthChange?.Invoke("Lose",currentHealthDecrease);
        }
    }
    public void checkfamePointSkill()
    {
        famePointLevel = famePoints / 30;
        onFamePointSkillChange?.Invoke(famePointLevel);
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
            famePoints -= currentFailPoints * 2;
        }
       
    }
    public void EndOfTheShowCalculation()
    {
        FamePointsCalculation();
        MoneyCalculation();
        currentFailPoints = 0;
    }
    public int GetFamePoints()
    {
        return famePoints;
    }public int GetCurrentFameLevel()
    {
        return famePointLevel;
    }public int GetMoney()
    {
        return currentMoney;
    }
    public void SpendMoney(int amount)
    {
        currentMoney -= amount;
    }
    public void addFamePoints(int amount)
    {
        famePoints += amount;
    }
    
}
