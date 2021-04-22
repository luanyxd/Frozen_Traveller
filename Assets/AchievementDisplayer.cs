using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
            Achievement ach = FindObjectOfType<GlobalAchieve>().findAllAchievementById(awardTag);
            if(ach == null)
            {
                Debug.Log("AwardTag "+awardTag+" not found!");
            }
            awardImage.GetComponent<Image>().sprite = ach.achImage;
            awardName.GetComponent<TextMeshProUGUI>().text = ach.description;
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
