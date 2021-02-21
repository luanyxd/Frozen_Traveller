﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    void Start()
    {
        HealthBar.HealthMax = health;
        HealthBar.HealthCurrent = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DamagePlayer(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
        HealthBar.HealthCurrent = health;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
