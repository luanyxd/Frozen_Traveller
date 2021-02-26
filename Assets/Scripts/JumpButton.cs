using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour
{
    public playercontroller player;

    public void Jump()
    {
        player.Jump();
    }
}
