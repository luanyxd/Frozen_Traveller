﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowballhit : MonoBehaviour
{
    public GameObject snowballPrefab;
    public GameObject snowballPrefab1;
    public GameObject snowballPrefab2;

    //private PlayerInputaction controls;

    //void Awake()
    //{
    //    controls = new PlayerInputaction();
    //    controls.GamePlay.Snowballhit.started += ctx => Shoot();

    //}

    //void OnEnable()
    //{
    //    controls.GamePlay.Enable();
    //}

    //void OnDisable()
    //{
    //    controls.GamePlay.Disable();
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        snowballPrefab.SetActive(true);
        Instantiate(snowballPrefab, transform.position, transform.rotation);
    }
    public void Shoot1()
    {
        snowballPrefab.SetActive(true);
        Instantiate(snowballPrefab, transform.position, transform.rotation);
        snowballPrefab1.SetActive(true);
        Instantiate(snowballPrefab1, transform.position, transform.rotation);
        snowballPrefab2.SetActive(true);
        Instantiate(snowballPrefab2, transform.position, transform.rotation);
    }


}
