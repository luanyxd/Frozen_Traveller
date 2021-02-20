using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollectedDisplayer : MonoBehaviour
{
    public TMP_Text amountText;
    public int amount;

    // Start is called before the first frame update
    void Start()
    {
        amount = 0;
        amountText.text = amount.ToString();
    }

    public void IncreaseCoin()
    {
        amount++;
        amountText.text = amount.ToString();
    }
}
