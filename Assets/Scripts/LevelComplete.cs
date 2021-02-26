using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelComplete : MonoBehaviour
{
    public LevelChanger levelChanger;
    public TMP_Text timeAmount;
    public TMP_Text coinAmount;
    public TMP_Text historyHighest;

    public void LoadNextLevel()
    {
        levelChanger.LoadNextLevel();
    }

    public void MainMenu()
    {
        levelChanger.LoadMainMenu();
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
