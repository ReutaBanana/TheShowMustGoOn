using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject storeScreen;

    [SerializeField] private Text _famePointsText;
    [SerializeField] private Text _moneyText;
    [SerializeField] private TextMeshProUGUI _showNumberText;
    private int showNumber = 1;

    [SerializeField] private Text _flayerPrice;
    //[SerializeField] private Text _cosumePrice;
    [SerializeField] private Text _improvisationPrice;

    [SerializeField] private SimonGame game;
    [SerializeField] private GameConstructor gameMananger;

    [SerializeField] private PlayerStats stats;
    [SerializeField] private PowerUpSystem powerUp;

    [SerializeField] private GameObject[] audiance;

    [SerializeField] private GameObject[] hearts;
    [SerializeField] private GameObject[] circleSquence;
    private int circlePoint = 0;
    private int currentShowSequenceAmount;
    // Start is called before the first frame update
    void Start()
    {
        game.onEndGameCondition += ShowUI;
        gameMananger.onShowEnd += EndLevelScreenShow;
        powerUp.onPowerupChange += ChangePriceUI;
        stats.onHealthChange += HeartMangment;
        stats.onFamePointSkillChange += FamePointLevelManagment;
        UpdateCircleUI();
    }

    private void FamePointLevelManagment(int obj)
    {
        audiance[obj - 1].SetActive(false);
        audiance[obj].SetActive(true);
    }

    void HeartMangment(string condition, int arg)
    {
        if(condition=="Lose")
        {
            hearts[arg-1].GetComponent<Image>(). color = Color.black;
        }
        else
        {
            hearts[arg - 1].SetActive(true);
        }
    }

    private void ChangePriceUI(string power, float price)
    {
        if (power == "Flayer")
        {
            _flayerPrice.text = ("Flayer Price: " + price);
        }
        else if(power == "Improvistation")
        {
            _improvisationPrice.text=("Improvistation Skill Price: " + price);
        }
    }
    private void Update()
    {
        _moneyText.text = ("Money Amount: " + stats.GetMoney());
        _famePointsText.text = ("Fame: " + stats.GetFamePoints());

    }
    private void EndLevelScreenShow()
    {
        StartCoroutine(EndGameUI());


    }
    public void EndLevelScreenHide()
    {
        storeScreen.SetActive(false);
    }
    private void UpdateCircleUI()
    {
        currentShowSequenceAmount = gameMananger.GetShowSequenceAmount();
        for(int i = 0; i<circleSquence.Length;i++)
        {
            circleSquence[i].GetComponent<Image>().color = Color.white;
            if (i < currentShowSequenceAmount)
                circleSquence[i].SetActive(true);
            else
                circleSquence[i].SetActive(false);
        }

    }
    private void ShowUI(string condition)
    {
        if (condition == "Win")
        {
            circleSquence[circlePoint].GetComponent<Image>(). color = Color.green;
        }
        else if (condition == "Lose")
        {
            circleSquence[circlePoint].GetComponent<Image>().color = Color.black;

        }
        circlePoint++;
    }

   IEnumerator ResetScreen()
    {
        yield return new WaitForSeconds(1f);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);

    } IEnumerator EndGameUI()
    {
        yield return new WaitForSeconds(2.5f);
        storeScreen.SetActive(true);
        showNumber++;
        _showNumberText.text=("Show " + showNumber);
        circlePoint = 0;
        UpdateCircleUI();
        stats.checkfamePointSkill();


    }
}
