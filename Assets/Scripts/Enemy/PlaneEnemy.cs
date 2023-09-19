using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneEnemy : MonoBehaviour
{
    public float moveSpeed = 1f;
    [SerializeField] float distance = 1500;
    [SerializeField] LayerMask layerPatrol;
    [SerializeField] LayerMask layerPlayer;


    [SerializeField] GameObject prefabBomb;
    [SerializeField] private float bombTime = 2f;
    private float currentBombTime;
    private bool canBomb = true;
    public GameObject shootPosition;
    private GameObject currentBomb;

    void Update()
    {
        transform.position += -transform.right * moveSpeed * Time.deltaTime;

        RaycastHit2D hitFloor = Physics2D.Raycast(transform.position, -transform.up, distance, layerPatrol);
        //Debug.DrawRay(transform.position, -transform.up, Color.red, distance); 


        RaycastHit2D hitPlayer = Physics2D.Raycast(transform.position, -transform.up, distance, layerPlayer);

        if (!hitFloor)
        {
            //Debug.Log("I'm not on terrain");
            transform.right = transform.right * -1;
        }

        if (hitPlayer && canBomb)
        {
            dropBomb();
            //Debug.Log("I'm sensing a player");
        } 
        else if (!canBomb)
        {
            resetBombTime();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthHandler hh = collision.gameObject.GetComponent<HealthHandler>();

        if (hh)
        {
            hh.ApplyDamage(1);
        }
    }

    private void dropBomb()
    {
        canBomb = false;
        currentBombTime = 0;
        Instantiate(prefabBomb, shootPosition.transform.position, Quaternion.identity);
    }

    private void resetBombTime()
    {
        currentBombTime += Time.deltaTime;

        if (currentBombTime >= bombTime)
        {
            canBomb = true;
        }
    }
}
