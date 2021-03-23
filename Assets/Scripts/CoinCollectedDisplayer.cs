using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollectedDisplayer : MonoBehaviour
{
    public TMP_Text amountText;
    public int startamount;
    public int currentamount;

    // Start is called before the first frame update
    void Start()
    {
        startamount = 0;
        currentamount = startamount;
        amountText.text = currentamount.ToString();
    }
    void Update()
    {
        amountText.text = currentamount.ToString();
    }

    public void IncreaseCoin()
    {
        currentamount++;
        amountText.text = currentamount.ToString();
    }
}
