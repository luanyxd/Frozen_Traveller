using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowballhit : MonoBehaviour
{
    public GameObject snowballPrefab;

    private PlayerInputaction controls;

    void Awake()
    {
        controls = new PlayerInputaction();
        controls.GamePlay.Snowballhit.started += ctx => Shoot();

    }

    void OnEnable()
    {
        controls.GamePlay.Enable();
    }

    void OnDisable()
    {
        controls.GamePlay.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        Instantiate(snowballPrefab, transform.position, transform.rotation);
    }

}
