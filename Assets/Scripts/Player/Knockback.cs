using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Knockback : MonoBehaviour
{
    private bool canKnock = true;
    [SerializeField] private float currentKnockbackTime;
    [SerializeField] private float knockTime = 3;
    private bool isKnockbacking = false;
    Collider2D col;
    [SerializeField] Animator animatorHolded;

    [SerializeField] private float kickForce = 10f;


    private void Start()
    {
        col = GetComponent<Collider2D>();
    }
    private void checkInputs()
    {
        if (Input.GetButton("Fire2"))
        {
            if (canKnock)
            {
                KnockbackAttack();
                animatorHolded.SetTrigger("MeleeKnockback");
            }
        }

        if (!canKnock)
        {
            KnockbackReset();
        }
    }

    private void KnockbackAttack()
    {
        canKnock = false;
        currentKnockbackTime = 0;
        //Debug.Log("I'm knockbacking");
    }

    private void KnockbackReset()
    {
        currentKnockbackTime += Time.deltaTime;

        if (currentKnockbackTime > knockTime)
        {
            canKnock = true;

            //Debug.Log("I can Knocback again");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {

            Rigidbody2D rbEnemy = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rbEnemy)
            {
                Vector2 difference = (collision.transform.position - transform.position).normalized;
                Vector2 force = difference * kickForce;
                rbEnemy.AddForce(force, ForceMode2D.Impulse);
                //if you don't want to take into consideration enemy's mass then use ForceMode.VelocityChange
                //Debug.Log("I'm kicking an enemy");

                HealthHandler hEnemy = collision.gameObject.GetComponent<HealthHandler>();

                if (hEnemy)
                {
                    hEnemy.ApplyDamage(1);
                }
            }
        }
    }
    void Update()
    {
        checkInputs();
    }
    void FixedUpdate()
    {
        //Debug.Log($"currentKnockbackTime:{(int)currentKnockbackTime}");
        //Debug.Log($"knockTime:{knockTime}");
    }

}



