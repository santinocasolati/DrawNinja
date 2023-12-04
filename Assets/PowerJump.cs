using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerJump : MonoBehaviour
{

    [SerializeField] float powerRatioJump;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthHandler hit = collision.GetComponent<HealthHandler>();

        if (hit != null)
        {
            hit.GetComponent<PlayerMovement>().jumpForce = 500 * powerRatioJump;
            Destroy(gameObject);
        }

    }
}
