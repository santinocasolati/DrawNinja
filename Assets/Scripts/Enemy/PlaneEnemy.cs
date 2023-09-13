using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneEnemy : MonoBehaviour
{
    public float moveSpeed = 1f;

    void Update()
    {
        transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);

        RaycastHit2D ray = Physics2D.Raycast(transform.position - transform.up, -transform.up * 2);
    }
}
