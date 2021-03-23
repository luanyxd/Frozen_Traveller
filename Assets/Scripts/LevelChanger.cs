using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelChanger : MonoBehaviour
{

    public Animator transition; // we can have different animators to play different animations

    public float transitionTime = 2f;

    private int levelToLoad;

    public void LoadNextLevel()
    {
        // without coroutine
        //FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);

        //// if you want to fade to next level immediately without giving animation time
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // with coroutine
        levelToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(LoadLevel(levelToLoad));
    }

    public void LoadCurrentLevel()
    {
        levelToLoad = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadLevel(levelToLoad));
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void LoadSpecificLevel(int levelIndex)
    {
        StartCoroutine(LoadLevel(levelIndex));
    }

    // with Coroutine

    IEnumerator LoadLevel(int levelIndex)
    {
        // play animation
        transition.SetTrigger("Start");

        // wait animation complete
        yield return new WaitForSeconds(transitionTime);

        // load next scene
        SceneManager.LoadScene(levelIndex);

        // TODO: set level name

    }

    // without Coroutine

    //public void FadeToLevel(int levelIndex)
    //{
    //    levelToLoad = levelIndex;
    //    animator.SetTrigger("FadeOut");
    //}

    //public void OnFadeComplete ()
    //{
    //    SceneManager.LoadScene(levelToLoad);
    //}
}
