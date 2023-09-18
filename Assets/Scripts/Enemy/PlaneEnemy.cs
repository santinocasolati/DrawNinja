using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneEnemy : MonoBehaviour
{
    public float moveSpeed = 1f;
    [SerializeField] float distance = 1500;
    [SerializeField] LayerMask layerPatrol;
    [SerializeField] LayerMask layerPlayer;

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

        if (hitPlayer)
        {
            dropBomb();
            //Debug.Log("I'm sensing a player");
        }

    }

    private void dropBomb()
    {
        // Implementar
    }
}
