using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ChangeModeButton : MonoBehaviour
{
    private playercontroller player;
    private playercontroller_2 player2;
    public TMP_Text amountText;
    private int bottleAmount;

    void Start()
    {
        player = FindObjectOfType<playercontroller>();
        player2 = FindObjectOfType<playercontroller_2>();
        if (SceneManager.GetActiveScene().buildIndex < 3)
            bottleAmount = 0;
        else
            bottleAmount = PlayerPrefs.GetInt("potion");
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
    public void ChangeMode2()
    {
        if (bottleAmount > 0)
        {
            bottleAmount -= 1;
            StartCoroutine(player2.BecomeAngryCoroutine());
        }
    }

    public int GetPotionAmount()
    {
        return bottleAmount;
    }
}
