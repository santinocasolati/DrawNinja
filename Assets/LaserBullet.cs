using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    [SerializeField] float velocity = 5f;

    public float lifeTime = 2f;
    private float currentLifeTime;
    private int dir;

    private int damage = 2;

    private void Awake()
    {
        dir = -1;
    }
    void Update()
    {
        transform.Translate(transform.right * dir * Time.deltaTime * velocity);

        currentLifeTime += Time.deltaTime;

        if (currentLifeTime > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthHandler hit = collision.GetComponent<HealthHandler>();

        if (hit != null && collision.gameObject.layer == 3)
        {
            hit.ApplyDamage(damage);
            Destroy(gameObject);
        }
    }
}
