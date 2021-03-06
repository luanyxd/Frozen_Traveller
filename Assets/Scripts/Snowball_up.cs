﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball_up : MonoBehaviour
{
    public float speed;
    public int demage;
    public float destroyDistance;

    private Rigidbody2D rb2d;
    private Vector3 startPos;
    private float up = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = -transform.right * speed + transform.up *(speed *up) ;
        startPos = transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        float distance = (transform.position - startPos).sqrMagnitude;
        if (distance > destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
