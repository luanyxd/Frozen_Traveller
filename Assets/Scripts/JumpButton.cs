using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour
{
    private playercontroller player;

    void Start()
    {
        player = FindObjectOfType<playercontroller>();
    }

    public void Jump()
    {
        player.Jump();
    }
}
