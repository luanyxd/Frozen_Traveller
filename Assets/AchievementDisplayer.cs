using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementDisplayer : MonoBehaviour
{
    public string awardTag;
    public GameObject awardImage;
    public GameObject questionImage;
    public GameObject awardName;
    public GameObject questionMarkList;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt(awardTag) == 1)
        {
            awardImage.SetActive(true);
            awardName.SetActive(true);
            questionImage.SetActive(false);
            questionMarkList.SetActive(false);
            Debug.Log("Questionmark should be disabled:"+awardTag);
            Debug.Log(questionImage.activeSelf);
            Debug.Log(questionMarkList.activeSelf);
        } else {
            awardImage.SetActive(false);
            awardName.SetActive(false);
            questionImage.SetActive(true);
            questionMarkList.SetActive(true);
        }
    }
}
