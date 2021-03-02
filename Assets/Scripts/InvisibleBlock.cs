using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBlock : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    void Start()
    {
        float x = target.position.x;
        float y = target.position.y;
        target.position = new Vector3(x, y, -100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float x = target.position.x;
            float y = target.position.y;
            target.position = new Vector3(x, y, -1);
        }
    }

}
