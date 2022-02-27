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
    public event Action finishGame;

    void Start()
    {
        ConstructSimonGames("Win");
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
                currentGame.SetSimonGame(shows[currentShow]._simonSpeedPerSequence, shows[currentShow]._simonAmountPerSequence[currentSequenceNumber]);
                currentSequenceNumber++;
            }
            else
            {
                currentShow++;
                onShowEnd?.Invoke();
                currentSequenceNumber = 0;
            }
            //add show 
        }
        else
        {
            finishGame?.Invoke();
        }
    }

    public int GetShowSequenceAmount()
    {
        if(currentShow<shows.Length)
        {
            return shows[currentShow]._simonAmountPerSequence.Length;

        }
        return shows[currentShow-1]._simonAmountPerSequence.Length;
    }
    public void BetweenLevelsShowConstructor()
    {
        StartCoroutine(ConsturctGameWithDelay());
    }
    IEnumerator ConsturctGameWithDelay()
    {
        yield return new WaitForSeconds(2f);
        ConstructSimonGames("random");
    }
}
