using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectMananger : MonoBehaviour
{
    [SerializeField] private AudioSource finishedSuccesfuly;
    [SerializeField] private AudioSource finishedBadly;
    [SerializeField] private SimonGame game;
    // Start is called before the first frame update
    void Start()
    {
        game.onEndGameCondition += YourTurnSFX;
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
}
