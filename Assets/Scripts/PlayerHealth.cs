using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    private PolygonCollider2D polygonCollider2D;
    public float hitBoxCdTime;
    private GameManager GM;
    void Start()
    {
        HealthBar.HealthMax = health;
        HealthBar.HealthCurrent = health;
        polygonCollider2D= GetComponent<PolygonCollider2D>();
        GM = FindObjectOfType<GameManager>();
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
            StartCoroutine(WaitToDie());
            GM.CompleteLevel(false);
            Destroy(gameObject);
        }
        polygonCollider2D.enabled = false;
        StartCoroutine(ShowPlayerHitbox());
    }

    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator ShowPlayerHitbox()
    {
        yield return new WaitForSeconds(hitBoxCdTime);
        polygonCollider2D.enabled = true;
    }
}
