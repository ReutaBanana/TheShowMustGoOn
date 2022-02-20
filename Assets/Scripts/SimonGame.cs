using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonGame : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private int _amount = 3;

    [SerializeField] private ColorChanger[] colors;

    private float t;
    private int randomBtn;
    private int lastRandomBtn=4;

    private List<int> simonSequance= new List<int>();
    private int[] simonSequenceArray;
    [SerializeField] PlayerInput input;
    private int[] playerInputArray;

    public event Action onWinCondition;
    public event Action onLoseCondition;

    void Update()
    {
        GenerateGame(_speed, _amount);
        if (_amount == 0)
        {
            simonSequenceArray = simonSequance.ToArray();
            playerInputArray = input.GetArray();
            if (playerInputArray.Length>= simonSequenceArray.Length)
            {
                if (CheckIfWin() == true)
                    onWinCondition?.Invoke();
                else
                    onLoseCondition?.Invoke();
            }
        }
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
                    colors[randomBtn].ChangeColor();
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
}
