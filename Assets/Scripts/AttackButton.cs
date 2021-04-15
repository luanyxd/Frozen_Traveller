using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    private playercontroller player;

    void Start()
    {
        player = FindObjectOfType<playercontroller>();
    }

    public void Attack()
    {
        player.Attack();
    }
}
