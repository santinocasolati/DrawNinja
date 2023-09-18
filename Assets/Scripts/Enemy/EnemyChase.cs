using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float moveSpeed;
    public int damage;
    Rigidbody2D rb;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthHandler hit = collision.gameObject.GetComponent<HealthHandler>();

        if (hit != null)
        {
            hit.ApplyDamage(damage);
        }
    }

    void Update()
    {
        transform.Translate(-transform.right * Time.deltaTime * moveSpeed);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
