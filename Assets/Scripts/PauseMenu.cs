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
        FindObjectOfType<LevelChanger>().LoadMainMenu();
        SaveSystem.SavePlayer(FindObjectOfType<playercontroller_2>(), SceneManager.GetActiveScene().buildIndex);
    }
}
