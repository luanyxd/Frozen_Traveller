using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IncreasingClock : MonoBehaviour
{

    public TMP_Text sec;
    public TMP_Text min;
    public float clock;

    // Start is called before the first frame update
    void Start()
    {
        sec.text = "00";
        min.text = "00";
    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;
        sec.text = string.Format("{0:00}", Mathf.Floor(clock % 60));
        min.text = string.Format("{0:00}", Mathf.Floor(clock / 60));
    }
}
