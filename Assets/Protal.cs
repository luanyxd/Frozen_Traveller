using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protal : MonoBehaviour
{
    public bool arriveProtal;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("player");
        arriveProtal = false;
    }

    void Update()
    {
        if (arriveProtal == false && Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) < 1)
        {
            arriveProtal = true;
            FindObjectOfType<LevelChanger>().FadeToNextLevel();
        }
    }
}   
