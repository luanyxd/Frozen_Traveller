using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameComplete : MonoBehaviour
{

    public TMP_Text timeAmount;
    public TMP_Text coinAmount;
    public TMP_Text historyHighest;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeAmount.text = PlayerPrefs.GetFloat("final_time").ToString("F2") + "s";
        coinAmount.text = PlayerPrefs.GetInt("final_score").ToString();
        historyHighest.text = PlayerPrefs.GetFloat("shortest_time").ToString("F2") + "s / " + PlayerPrefs.GetInt("highest_score").ToString();
    }
}
