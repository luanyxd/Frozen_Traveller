using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int health;
    public int coins;

    public PlayerData (playercontroller_2 player, int levelNumber)
    {
        coins = player.coinCollectedDisplayer.currentamount;
        level = levelNumber;
    }
}
