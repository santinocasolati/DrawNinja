using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{

    [SerializeField] float timeToExplode;
    [SerializeField] float radius;
    [SerializeField] float explotionForce;

    [SerializeField] LayerMask layerMask;

    private float currentTime;

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeToExplode) MakeExplosion();
    }

    void MakeExplosion()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);

        foreach (Collider2D col in cols)
        {
            Rigidbody2D rbCol = col.gameObject.GetComponent<Rigidbody2D>();
            if (rbCol)
            {
                rbCol.AddForce((col.transform.position - transform.position) * explotionForce, ForceMode2D.Impulse);

                HealthHandler hh = col.gameObject.GetComponent<HealthHandler>();
                if (hh)
                {
                    hh.ApplyDamage(5);
                }
            }
        }
        Destroy(gameObject);
        //Parent 
        Destroy(transform.parent.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
