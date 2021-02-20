using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModeButton : MonoBehaviour
{
    public playercontroller player;
    public GameObject angry;
    public GameObject normal;

    public void ChangeMode()
    {
        if (angry.activeSelf == true)
        {
            angry.SetActive(false);
            normal.SetActive(true);
        } else
        {
            angry.SetActive(true);
            normal.SetActive(false);
        }
        player.ChangeMode();
    }
}
