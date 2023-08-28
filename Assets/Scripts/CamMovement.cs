using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    public bool camMoving = true;

    void Update()
    {
        if (camMoving)
        {
            Vector3 target = new Vector3(player.position.x, transform.position.y, transform.position.z);

            transform.position = target;
        }
    }
}
