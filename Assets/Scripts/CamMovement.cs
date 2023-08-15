using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    public bool camMoving = true;
    [SerializeField] private float smoothSpeed = 0.25f;

    void Update()
    {
        if (camMoving)
        {
            Vector3 target = new Vector3(player.position.x, transform.position.y, transform.position.z);

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, target, smoothSpeed);

            transform.position = smoothedPosition;
        }
    }
}
