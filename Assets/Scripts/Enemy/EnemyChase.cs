using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float moveSpeed;
    public int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthHandler hit = collision.gameObject.GetComponent<HealthHandler>();

        if (hit != null)
        {
            hit.ApplyDamage(damage);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Translate(-transform.right * Time.deltaTime * moveSpeed);
    }
}
