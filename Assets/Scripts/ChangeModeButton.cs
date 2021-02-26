using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModeButton : MonoBehaviour
{
    public playercontroller player;

    public void ChangeMode()
    {
        //player.ChangeMode();
        StartCoroutine(player.BecomeAngryCoroutine());
    }
}
