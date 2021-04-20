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

    public void SetlevelMessage(bool winGame, float totalTime, int score)
    {
        string level = (SceneManager.GetActiveScene().buildIndex / 2).ToString();
        if (winGame)
        {
            win = true;
            winText.SetActive(true);
            loseText.SetActive(false);
            retryButton.SetActive(false);
            nextButton.SetActive(true);

            // consider history records
            float shortest_time;
            int highest_score;
            if (PlayerPrefs.GetInt("highest_" + level+ "_score", -1) == -1)
            {
                // no history records
                shortest_time = 9999f;
                highest_score = 0;
                PlayerPrefs.SetFloat("shortest_" + level + "_time", totalTime);
                PlayerPrefs.SetInt("highest_" + level + "_score", score);
            } else
            {
                // have history
                shortest_time = PlayerPrefs.GetFloat("shortest_" + level + "_time");
                highest_score = PlayerPrefs.GetInt("highest_" + level + "_score");
                if (shortest_time > totalTime)
                    PlayerPrefs.SetFloat("shortest_" + level + "_time", totalTime);
                if (highest_score < score)
                    PlayerPrefs.SetInt("highest_" + level + "_score", score);
            }
            SetHistoryHighest(shortest_time, highest_score);

            // save potion, final_time, final_score
            if (level == "1")
            {
                PlayerPrefs.SetInt("potion", FindObjectOfType<ChangeModeButton>().GetPotionAmount());
                PlayerPrefs.SetFloat("final_time", totalTime);
                PlayerPrefs.SetInt("final_score", score);
            } else
            {
                PlayerPrefs.SetInt("potion", PlayerPrefs.GetInt("potion") + FindObjectOfType<ChangeModeButton>().GetPotionAmount());
                PlayerPrefs.SetFloat("final_time", PlayerPrefs.GetFloat("final_time") +totalTime);
                PlayerPrefs.SetInt("final_score", PlayerPrefs.GetInt("final_score") + score);
            }
            
            // save for continue: levelnumber, previous(history, final_time, final_score, potion)
            if (PlayerPrefs.GetInt("previous_level",-1) == -1 || PlayerPrefs.GetInt("previous_level") <= SceneManager.GetActiveScene().buildIndex + 1)
            {
                PlayerPrefs.SetInt("previous_level", SceneManager.GetActiveScene().buildIndex + 1);
                PlayerPrefs.SetFloat("previous_" + "shortest_" + level + "_time", PlayerPrefs.GetFloat("shortest_" + level + "_time"));
                PlayerPrefs.SetInt("previous_" + "highest_" + level + "_score", PlayerPrefs.GetInt("highest_" + level + "_score"));
                PlayerPrefs.SetFloat("previous_" + "final_time", PlayerPrefs.GetFloat("final_time"));
                PlayerPrefs.SetInt("previous_" + "final_score", PlayerPrefs.GetInt("final_score"));
                PlayerPrefs.SetInt("previous_" + "potion", PlayerPrefs.GetInt("potion"));
            }

            //SaveSystem.SavePlayer(FindObjectOfType<playercontroller_2>(), SceneManager.GetActiveScene().buildIndex + 1);
        } else
        {
            win = false;
            winText.SetActive(false);
            loseText.SetActive(true);
            retryButton.SetActive(true);
            nextButton.SetActive(false);

            // consider history records
            float shortest_time;
            int highest_score;
            if (PlayerPrefs.GetInt("highest_" + level + "_score", -1) == -1)
            {
                // no history records
                shortest_time = 9999f;
                highest_score = 0;
                PlayerPrefs.SetFloat("shortest_" + level + "_time", totalTime);
                PlayerPrefs.SetInt("highest_" + level + "_score", score);
            }
            else
            {
                // have history
                shortest_time = PlayerPrefs.GetFloat("shortest_" + level + "_time");
                highest_score = PlayerPrefs.GetInt("highest_" + level + "_score");
            }
            SetHistoryHighest(shortest_time, highest_score);

            // save for continue: levelnumber, previous(history, final_time, final_score, potion)
            if (PlayerPrefs.GetInt("previous_level", -1) == -1 || PlayerPrefs.GetInt("previous_level") <= SceneManager.GetActiveScene().buildIndex)
            {
                PlayerPrefs.SetInt("previous_level", SceneManager.GetActiveScene().buildIndex);
                PlayerPrefs.SetFloat("previous_" + "shortest_" + level + "_time", PlayerPrefs.GetFloat("shortest_" + level + "_time"));
                PlayerPrefs.SetInt("previous_" + "highest_" + level + "_score", PlayerPrefs.GetInt("highest_" + level + "_score"));
                PlayerPrefs.SetFloat("previous_" + "final_time", PlayerPrefs.GetFloat("final_time"));
                PlayerPrefs.SetInt("previous_" + "final_score", PlayerPrefs.GetInt("final_score"));
                PlayerPrefs.SetInt("potion", PlayerPrefs.GetInt("potion"));
            }

            //SaveSystem.SavePlayer(FindObjectOfType<playercontroller_2>(), SceneManager.GetActiveScene().buildIndex);
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
