using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject storeScreen;

    [SerializeField] private SimonGame game;
    [SerializeField] private SimonLevelConstructor gameMananger;
    // Start is called before the first frame update
    void Start()
    {
        game.onEndGameCondition += ShowUI;
        gameMananger.onLevelEnd += EndLevelScreenShow;
    }

    private void EndLevelScreenShow()
    {
        storeScreen.SetActive(true);
    } public void EndLevelScreenHide()
    {
        Debug.Log("meow");
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
