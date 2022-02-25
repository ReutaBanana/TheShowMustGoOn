using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject storeScreen;

    [SerializeField] private Text _famePointsText;
    [SerializeField] private Text _moneyText;

    [SerializeField] private Text _flayerPrice;
    //[SerializeField] private Text _cosumePrice;
    //[SerializeField] private Text _improvisationPrice;

    [SerializeField] private SimonGame game;
    [SerializeField] private GameConstructor gameMananger;

    [SerializeField] private PlayerStats stats;
    [SerializeField] private PowerUpSystem powerUp;
    // Start is called before the first frame update
    void Start()
    {
        game.onEndGameCondition += ShowUI;
        gameMananger.onShowEnd += EndLevelScreenShow;
        powerUp.onPricePerFlayerChange += changeFlayerPrice;
    }
    private void changeFlayerPrice(float price)
    {
        _flayerPrice.text = ("Flayer Price: " + price);
    }
    private void Update()
    {
        _moneyText.text = ("Money Amount: " + stats.GetMoney());
        _famePointsText.text = ("Fame: " + stats.GetFamePoints());
    }
    private void EndLevelScreenShow()
    {
       
        storeScreen.SetActive(true);

    } public void EndLevelScreenHide()
    {
        storeScreen.SetActive(false);
    }
    private void ShowUI(string condition)
    {
        if (condition == "Win")
            winScreen.SetActive(true);
        else if (condition == "Lose")
            loseScreen.SetActive(true);

        StartCoroutine(ResetScreen());
    }

   IEnumerator ResetScreen()
    {
        yield return new WaitForSeconds(1f);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);

    }
}
