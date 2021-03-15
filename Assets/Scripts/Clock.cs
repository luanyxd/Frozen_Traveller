using System.Collections;
using System.Collections.Generic;
using UnityEngine;
        
using TMPro;

public class Clock : MonoBehaviour
{

    public TMP_Text sec;
    public TMP_Text min;
    public float clock;

    public bool timeActive = false;

    // Start is called before the first frame update
    void Start()
    {
        if (timeActive)
        {
            if (Mathf.Ceil(clock % 60) == 60)
            {
                sec.text = "00";
                min.text = string.Format("{0:00}", Mathf.Ceil(clock / 60));
            } else
            {
                sec.text = string.Format("{0:00}", Mathf.Ceil(clock % 60));
                min.text = string.Format("{0:00}", Mathf.Floor(clock / 60));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeActive)
        {
            //Debug.Log(clock);
            clock -= Time.deltaTime;
            if (Mathf.Ceil(clock % 60) == 60)
            {
                sec.text = "00";
                if (Mathf.Ceil(clock / 60) <= 0)
                {
                    min.text = "00";
                } else
                {
                    min.text = string.Format("{0:00}", Mathf.Ceil(clock / 60));
                }
            }
            else
            {
                sec.text = string.Format("{0:00}", Mathf.Ceil(clock % 60));
                if (Mathf.Floor(clock / 60) <= 0)
                {
                    min.text = "00";
                }
                else
                {
                    min.text = string.Format("{0:00}", Mathf.Floor(clock / 60));
                }
            }
            if (Mathf.Abs(clock - 0f) < 0.01f)
            {
                sec.text = "00";
                min.text = "00";
                timeActive = false;
            }
        }

    }
}
