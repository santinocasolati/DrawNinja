using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] int bulletsAdded = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthHandler hit = collision.GetComponent<HealthHandler>();

        if (hit != null)
        {
            BulletsManager.instance.AddBullets(bulletsAdded);
            Destroy(gameObject);
        }
    }
}
