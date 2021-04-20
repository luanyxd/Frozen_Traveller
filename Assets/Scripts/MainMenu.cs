using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // LoadScene("SceneName") give the name of the next scene
        FindObjectOfType<LevelChanger>().LoadNextLevel();
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }

    public void Continue()
    {
        //PlayerData data = SaveSystem.LoadPlayer();
        //if (data != null)
        //{
        //    FindObjectOfType<LevelChanger>().LoadSpecificLevel(data.level);
        //}

        int previous_level = PlayerPrefs.GetInt("previous_level", -1);
        print("previous_level: " + previous_level.ToString());
        if (previous_level == -1)
            return;
        string level = (previous_level / 2).ToString();
        PlayerPrefs.SetFloat("shortest_" + level + "_time", PlayerPrefs.GetFloat("previous_" + "shortest_" + level + "_time"));
        PlayerPrefs.SetInt("highest_" + level + "_score", PlayerPrefs.GetInt("previous_" + "highest_" + level + "_score"));
        PlayerPrefs.SetFloat("final_time", PlayerPrefs.GetFloat("previous_" + "final_time"));
        PlayerPrefs.SetInt("final_score", PlayerPrefs.GetInt("previous_" + "final_score"));
        PlayerPrefs.SetInt("potion", PlayerPrefs.GetInt("previous_" + "potion"));

        FindObjectOfType<LevelChanger>().LoadSpecificLevel(previous_level);
    }
}
