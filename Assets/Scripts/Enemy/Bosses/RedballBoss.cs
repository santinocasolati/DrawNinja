using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedballBoss : MonoBehaviour
{
    private float temporalAxis;
    [SerializeField] private float amplitude;
    [SerializeField] private float floatingSpeed;
    private Vector3 temporalPosition;
    private Vector3 staticPosition;

    private float currentAtackTime;

    private Animator animator;

    [SerializeField] private float attackTime = 5;

    private void Start()
    {
        temporalAxis = transform.position.y;
        staticPosition = transform.position;
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    private void Update()
    {
        //Movement controller
        floatingMov();

        currentAtackTime += Time.deltaTime;
        castAttack();
    }

    private void floatingMov()
    {
        temporalPosition.y = temporalAxis + amplitude * Mathf.Sin(floatingSpeed * Time.time);

        //Mantain original values
        temporalPosition.x = staticPosition.x;
        temporalPosition.z = staticPosition.z;
        
        transform.position = temporalPosition;
    }

    private void castAttack()
    {
        if (currentAtackTime >= attackTime)
        {
            //animator.SetTrigger("isAttacking");
            spawnLasers();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            animator.SetTrigger("hasBeenHurt");
        }
    }

    private void animHurt()
    {

    }

    private void spawnLasers()
    {

    }
}
