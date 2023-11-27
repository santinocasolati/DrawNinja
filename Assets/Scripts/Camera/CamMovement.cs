using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float deviationY = 1f;
    public bool camMoving = true;

    void Update()
    {
        if (camMoving)
        {
            Vector3 target = new Vector3(player.position.x, player.position.y + deviationY, transform.position.z);

            transform.position = target;
        }
    }

    public void setCamMoving(bool value)
    {
        camMoving = value;
    }
}