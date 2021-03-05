﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelComplete : MonoBehaviour
{
    public LevelChanger levelChanger;
    public TMP_Text levelMessage;
    public TMP_Text timeAmount;
    public TMP_Text coinAmount;
    public TMP_Text historyHighest;
    public GameObject retryButton;
    public GameObject nextButton;

    private bool win;

    public void LoadNextLevel()
    {
        levelChanger.LoadNextLevel();
    }

    public void MainMenu()
    {
        levelChanger.LoadMainMenu();
    }

    public void Retry()
    {
        levelChanger.LoadCurrentLevel();
    }

    public void SetlevelMessage(bool winGame)
    {
        if (winGame)
        {
            win = true;
            levelMessage.text = "YOU WIN";
            retryButton.SetActive(false);
            nextButton.SetActive(true);
        } else
        {
            win = false;
            levelMessage.text = "YOU LOSE";
            retryButton.SetActive(true);
            nextButton.SetActive(false);
        }
    }

    public void SetTimeAmount(float totalTime)
    {
        timeAmount.text = totalTime.ToString("F2") + "s";
    }

    public void SetCoinAmount(string coins)
    {
        coinAmount.text = coins;
    }

    public void SetHistoryHighest(float highestTime, int highestCoins)
    {
        historyHighest.text = highestTime.ToString("F2") + "s / " + highestCoins.ToString(); 
    }
}
