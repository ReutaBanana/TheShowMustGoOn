using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonLevelConstructor : MonoBehaviour
{
    [SerializeField] private SimonLevel[] levels;
    private int currentLevel = 0;
    [SerializeField] private SimonGame game;
    private int sequenceAmount;
    private int currentSequenceNumber = 0;

    public event Action onLevelEnd;
    // Start is called before the first frame update
    void Start()
    {
        sequenceAmount = levels[currentLevel]._simonAmountPerSequence.Length;
        game.onEndGameCondition += ConstructSimonGames;
    }

    public void ConstructSimonGames(string condition)
    {
        if(currentLevel<levels.Length)
        {
            sequenceAmount = levels[currentLevel]._simonAmountPerSequence.Length;
            if (currentSequenceNumber < sequenceAmount)
            {
                game.SetSimonGame(levels[currentLevel]._simonSpeedPerSequence[currentSequenceNumber], levels[currentLevel]._simonAmountPerSequence[currentSequenceNumber]);
                currentSequenceNumber++;
            }
            else
            {
                Debug.Log("No more games babe");
                currentLevel++;
                onLevelEnd?.Invoke();
                currentSequenceNumber = 0;
            }
            //add show 
        }
        else
        {
            Debug.Log("no more games");
        }
    }
}
