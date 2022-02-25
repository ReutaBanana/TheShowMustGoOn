using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level",menuName ="Level")]
public class SimonShow : ScriptableObject
{
    public float _simonSpeedPerSequence;
    public int[] _simonAmountPerSequence;
}
