using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false; // help AudioManager to decide whether if game is paused
    public GameObject pauseMenuUI;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void MainMenu()
    {
        GameIsPaused = false;
        // back to main menu, may consider other settings
        Time.timeScale = 1f;
        int previous_level = PlayerPrefs.GetInt("previous_level", -1);
        Debug.Log("in pause, press mainmenu, previous_level: " + PlayerPrefs.GetInt("previous_level"));
        FindObjectOfType<LevelChanger>().LoadMainMenu();

        if (PlayerPrefs.GetInt("previous_level", -1) == -1 || PlayerPrefs.GetInt("previous_level") <= SceneManager.GetActiveScene().buildIndex)
        {
            string level = (SceneManager.GetActiveScene().buildIndex / 2).ToString();
            Debug.Log("lose, previous level: " + PlayerPrefs.GetInt("previous_level").ToString());
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
