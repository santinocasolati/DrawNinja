using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
    [SerializeField] int heal = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthHandler hit = collision.GetComponent<HealthHandler>();

        if (hit != null)
        {
            bool healed = hit.Heal(heal);

            if (healed)
            {
                Destroy(gameObject);
            }
        }
    }
}
