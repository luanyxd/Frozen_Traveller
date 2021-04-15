using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelComplete : MonoBehaviour
{
    public LevelChanger levelChanger;
    public GameObject winText;
    public GameObject loseText;
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
        Debug.Log("Retry!");
        levelChanger.LoadCurrentLevel();
    }

    public void SetlevelMessage(bool winGame)
    {
        if (winGame)
        {
            win = true;
            winText.SetActive(true);
            loseText.SetActive(false);
            retryButton.SetActive(false);
            nextButton.SetActive(true);

            SaveSystem.SavePlayer(FindObjectOfType<playercontroller_2>(), SceneManager.GetActiveScene().buildIndex + 1);
        } else
        {
            win = false;
            winText.SetActive(false);
            loseText.SetActive(true);
            retryButton.SetActive(true);
            nextButton.SetActive(false);

            SaveSystem.SavePlayer(FindObjectOfType<playercontroller_2>(), SceneManager.GetActiveScene().buildIndex);
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
