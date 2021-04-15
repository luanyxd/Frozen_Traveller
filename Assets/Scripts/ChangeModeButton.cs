using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeModeButton : MonoBehaviour
{
    private playercontroller player;
    public TMP_Text amountText;
    private int bottleAmount;

    void Start()
    {
        player = FindObjectOfType<playercontroller>();
        bottleAmount = 0;
        amountText.text = bottleAmount.ToString();
    }

    void Update() {
        amountText.text = bottleAmount.ToString();
    }

    public void SetBottleAmount(int num)
    {
        bottleAmount = num;
    }

    public void increaseBottleAmount()
    {
        bottleAmount += 1;
    }

    public void ChangeMode()
    {
        if (bottleAmount > 0)
        {
            bottleAmount -= 1;
            StartCoroutine(player.BecomeAngryCoroutine());
        }
    }
}
