using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public List<int> playerInput = new List<int>();

    public void inputFromBtn(int btnNumber)
    {
        playerInput.Add(btnNumber);
    }

    public int[] GetArray()
    {
        return playerInput.ToArray();
    }

}
