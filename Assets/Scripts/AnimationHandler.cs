using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator animator;
    [SerializeField] SimonGame game;

    public event Action onEndofAnimation;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        game.onEndGameCondition += NextAnimation;
        
    }

    public void NextAnimation(string condition)
    {
        //add failed animaton state
        animator.SetTrigger("Next");
    }

    private void onEnd()
    {
        onEndofAnimation?.Invoke();
    }
   
}
