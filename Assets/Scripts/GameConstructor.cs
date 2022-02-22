using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstructor : MonoBehaviour
{
    // plays simon shows (and the sequences inside a show) which creates the game

    [SerializeField] private SimonShow[] shows;
    private int currentShow = 0;

    [SerializeField] private SimonGame currentGame;
    private int currentSequenceAmount;
    private int currentSequenceNumber = 0;

    public event Action onShowEnd;

    void Start()
    {
        currentSequenceAmount = shows[currentShow]._simonAmountPerSequence.Length;
        currentGame.onEndGameCondition += ConstructSimonGames;
    }

    public void ConstructSimonGames(string condition)
    {
        if(currentShow<shows.Length)
        {
            currentSequenceAmount = shows[currentShow]._simonAmountPerSequence.Length;
            if (currentSequenceNumber < currentSequenceAmount)
            {
                currentGame.SetSimonGame(shows[currentShow]._simonSpeedPerSequence[currentSequenceNumber], shows[currentShow]._simonAmountPerSequence[currentSequenceNumber]);
                currentSequenceNumber++;
            }
            else
            {
                onShowEnd?.Invoke();
                currentShow++;
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
