﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameComplete : MonoBehaviour
{

    public TMP_Text timeAmount;
    public TMP_Text coinAmount;
    public TMP_Text historyHighest;
    public GameObject student;
    public GameObject scholar;
    public GameObject environmentalist;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeAmount.text = PlayerPrefs.GetFloat("final_time").ToString("F2") + "s";
        coinAmount.text = PlayerPrefs.GetInt("final_score").ToString();

        if (PlayerPrefs.GetInt("final_score") < 100)
        {
            student.SetActive(true);
            scholar.SetActive(false);
            environmentalist.SetActive(false);
            FindObjectOfType<GlobalAchieve>().TriggerAchievementById("finaleval_student");
        } else if (PlayerPrefs.GetInt("final_score") < 200)
        {
            student.SetActive(false);
            scholar.SetActive(true);
            environmentalist.SetActive(false);
            FindObjectOfType<GlobalAchieve>().TriggerAchievementById("finaleval_scholar");
        } else
        {
            student.SetActive(false);
            scholar.SetActive(false);
            environmentalist.SetActive(true);
            FindObjectOfType<GlobalAchieve>().TriggerAchievementById("finaleval_environmentalist");
        }

        if (PlayerPrefs.GetFloat("shortest_time", -1f) == -1f)
            historyHighest.text = "9999s / 0";
        else
        {
            if (PlayerPrefs.GetFloat("shortest_time") >= PlayerPrefs.GetFloat("final_time") && PlayerPrefs.GetInt("highest_score") <= PlayerPrefs.GetInt("final_score"))
            {
                historyHighest.text = PlayerPrefs.GetFloat("final_time").ToString("F2") + "s / " + PlayerPrefs.GetInt("final_score").ToString();
                PlayerPrefs.SetFloat("shortest_time", PlayerPrefs.GetFloat("final_time"));
                PlayerPrefs.GetInt("highest_score", PlayerPrefs.GetInt("final_score"));
            } else
            {
                historyHighest.text = PlayerPrefs.GetFloat("shortest_time").ToString("F2") + "s / " + PlayerPrefs.GetInt("highest_score").ToString();
            }
        }
    }
}
