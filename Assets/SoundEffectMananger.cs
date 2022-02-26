using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectMananger : MonoBehaviour
{
    [SerializeField] private AudioSource finishedSuccesfuly;
    [SerializeField] private AudioSource finishedBadly;
    [SerializeField] private AudioSource failed;
    [SerializeField] private SimonGame game;
    [SerializeField] private PlayerStats stats;
    // Start is called before the first frame update
    void Start()
    {
        game.onEndGameCondition += YourTurnSFX;
        stats.onHealthChange += LoseGameSound;
    }

    private void YourTurnSFX(string condition)
    {
        if (condition == "Win")
        {
            finishedSuccesfuly.Play();
        }
        else
        {
            finishedBadly.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoseGameSound(string arg1, int arg2)
    {
        if (arg1 == "Lose Game")
        {
            failed.Play();
        }
    }
}
