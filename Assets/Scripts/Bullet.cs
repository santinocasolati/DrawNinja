using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float velocity = 5f;

    public float lifeTime = 2f;
    private float currentLifeTime;

    void Update()
    {
        transform.Translate(transform.right * Time.deltaTime * velocity);

        currentLifeTime += Time.deltaTime;

        if (currentLifeTime > lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
