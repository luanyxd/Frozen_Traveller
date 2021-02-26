﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI;
    public LevelComplete levelComplete;
    public TMP_Text coinAmount;

    public void CompleteLevel()
    {
        levelComplete.SetTimeAmount(Time.timeSinceLevelLoad);
        levelComplete.SetCoinAmount(coinAmount.text);

        // TODO: set history highest

        completeLevelUI.SetActive(true);
    }
}
