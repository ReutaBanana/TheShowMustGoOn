using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonGame : MonoBehaviour
{
    private float _speed = 1;
     private int _amount = 6;

    [SerializeField] private ButtonActivator[] colors;
    [SerializeField] private AnimationHandler animationHandler;

    private float t;
    private int randomBtn;
    private int lastRandomBtn = 4;

    private List<int> simonSequance = new List<int>();
    private int[] simonSequenceArray;

    [SerializeField] PlayerInput input;
    private int[] playerInputArray;

    public event Action<string> onEndGameCondition;

    public bool isFinished;
    private bool isReady=true;
    private void Start()
    {
        animationHandler.onEndofAnimation += ResetIsReady;
    }
    public void SetSimonGame(float speed,int amount)
    {
        _speed = speed;
        _amount = amount;
        isFinished = false;
        simonSequance.Clear();

    }
    void Update()
    {
        GenerateGame(_speed, _amount);
        if (_amount == 0)
        {
            foreach (ButtonActivator button in colors)
            {
                button.SetToInteractable();
            }
            simonSequenceArray = simonSequance.ToArray();
            playerInputArray = input.GetArray();
            if (playerInputArray.Length >= simonSequenceArray.Length)
            {
                if (CheckIfWin() == true)
                    onEndGameCondition?.Invoke("Win");
                else
                    onEndGameCondition?.Invoke("Lose");
                isFinished = true;
            }
        }
        else
            isFinished = false;
    }

    private void ResetIsReady()
    {
        isReady = true;
        isFinished = false;
    }
    private bool CheckIfWin()
    {
        playerInputArray = input.GetArray();
        for (int i = 0; i < simonSequenceArray.Length; i++)
        {
            if (playerInputArray[i] != simonSequenceArray[i])
                return false;
        }
        return true;   
    }

    private void GenerateGame(float speed, int amount)
    {
        if(!isFinished&&isReady)
        {
            foreach (ButtonActivator button in colors)
            {
                button.SetToNonInteractable();
            }

            if (t < _speed)
        {
            t += Time.deltaTime;
        }

        else if (amount != 0)
        {
            t = 0;

            randomBtn = UnityEngine.Random.Range(0, 4);

            while (true)
            {
                if (lastRandomBtn != randomBtn)
                {
                    lastRandomBtn = randomBtn;
                    simonSequance.Add(randomBtn);
                    colors[randomBtn].ActivateBtn();
                    _amount--;
                    break;
                }
                else
                {
                    randomBtn = UnityEngine.Random.Range(0, 4);
                }
            }
        }
        }
        else if(isFinished ==true)
        {
            isReady = false;
           
        }
    }

}
