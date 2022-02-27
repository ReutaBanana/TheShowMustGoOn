using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject finishGameScreen;
    [SerializeField] private GameObject loseGame;
    [SerializeField] private GameObject storeScreen;

    [SerializeField] private TextMeshProUGUI _famePointsText;
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _showNumberText;
    private int showNumber = 1;

    [SerializeField] private Button FlyerButton;
    [SerializeField] private Button ImprovisationButton;

    [SerializeField] private TextMeshProUGUI _flayerPrice;
    //[SerializeField] private Text _cosumePrice;
    [SerializeField] private TextMeshProUGUI _improvisationPrice;

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
        powerUp.onDisableButtonEvent += DisablePowerUpButton;
        stats.onHealthChange += HeartMangment;
        stats.onFamePointSkillChange += FamePointLevelManagment;
        stats.onWinGame += WinGameUI;
        gameMananger.finishGame += FinishGameUI;
        UpdateCircleUI();
    }

    private void FinishGameUI()
    {
        finishGameScreen.SetActive(true);
    }

    private void DisablePowerUpButton(string obj)
    {
        if (obj == "Flyer")
        {
            FlyerButton.interactable = false;
        }
        else if(obj=="Improviastion")
        {
            ImprovisationButton.interactable = false;
        }
    }

    private void WinGameUI()
    {
        winScreen.SetActive(true);    }

    private void FamePointLevelManagment(int obj)
    {
        audiance[obj - 1].SetActive(false);
        audiance[obj].SetActive(true);
    }

    void HeartMangment(string condition, int arg)
    {
        if(condition=="Lose"&&arg>0&&arg<5)
        {
            hearts[arg-1].GetComponent<Image>(). color = Color.black;
        }
        else if(arg > 0 && arg <= 5)
        {
            hearts[arg - 1].SetActive(true);
        }

        if(condition=="Lose Game")
        {
            loseGame.SetActive(true);
        }
    }

    private void ChangePriceUI(string power, float price)
    {

        if (power == "Flayer")
        {
            if(price==404)
            {
                _flayerPrice.text = ("No more flyers available...");

            }
            else
            {
                _flayerPrice.text = ("Flyer Price: " + price);

            }
        }
        else if(power == "Improvistation")
        {
            if (price == 404)
            {
                _improvisationPrice.text = ("No more improvistation skill available...");

            }
            else
            {
                _improvisationPrice.text = ("Improvistation Skill Price: " + price);
            }
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
        finishGameScreen.SetActive(false);

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
