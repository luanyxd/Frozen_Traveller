using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollectedDisplayer : MonoBehaviour
{
    public TMP_Text amountText;
    public int startamount;
    public static int currentamount;

    // Start is called before the first frame update
    void Start()
    {
        startamount = 0;
        //Debug.Log(currentamount);
        currentamount = startamount;
        //amountText.text = amount.ToString();
    }
    void Update()
    {
        //Debug.Log(currentamount);
        amountText.text = currentamount.ToString();
    }
    /*public void IncreaseCoin()
    {
        amount++;
        amountText.text = amount.ToString();
    }*/
}
