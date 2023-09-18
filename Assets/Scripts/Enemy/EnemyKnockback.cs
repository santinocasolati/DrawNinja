using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    public float knockbackMultiplier = 50;
    public float enemyKnockback = 1;
    private Rigidbody2D enemyRb;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == GameObject.Find("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb)
            {
                rb.AddForce((collision.gameObject.transform.position - transform.position) * knockbackMultiplier, ForceMode2D.Impulse);
                
                if (enemyRb)
                {
                    enemyRb.AddForce(-(collision.gameObject.transform.position - transform.position) * enemyKnockback, ForceMode2D.Impulse);
                }
            }
        }
    }
}
