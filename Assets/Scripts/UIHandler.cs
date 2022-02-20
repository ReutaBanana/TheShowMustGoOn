using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;

    [SerializeField] private SimonGame game;
    // Start is called before the first frame update
    void Start()
    {
        game.onWinCondition += WinUI;
        game.onLoseCondition += LostUI;
        
    }

    private void WinUI()
    {
        winScreen.SetActive(true);
    }private void LostUI()
    {
        loseScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
