using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public List<int> playerInput = new List<int>();
    [SerializeField] private SimonGame game;
    private void Start()
    {
        game.onEndGameCondition += ResetInput;
    }
    public void ResetInput(string condition)
    {
        playerInput.Clear();
    }
    public void inputFromBtn(int btnNumber)
    {
        playerInput.Add(btnNumber);
    }

    public int[] GetArray()
    {
        return playerInput.ToArray();
    }

}
