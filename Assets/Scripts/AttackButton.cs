using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public playercontroller player;
    public Snowballhit snowballhit;

    public void Attack()
    {
        player.Attack();
        snowballhit.Shoot();
    }
}
