using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaximum(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    //// player health framework codes

    //public int maxHealth = 100;
    //public int currentHealth;

    //public HealthBar healthBar;

    //private void Start()
    //{
    //    currentHealth = maxHealth;
    //    healthBar.SetMaximum(maxHealth);
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        TakeDamage(20);
    //    }
    //}

    //void TakeDamage(int damage)
    //{
    //    currentHealth -= damage;
    //    healthBar.SetHealth(currentHealth);
    //}
}


