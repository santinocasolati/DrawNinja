using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float multiplierEffect;


    Transform cameraTransform;
    Vector3 lastPositionCamera;
    float width;
    float posY;

    void Start()
    {
        posY = transform.position.y;
        cameraTransform = Camera.main.transform;
        lastPositionCamera = cameraTransform.position;
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        Vector3 newPos = cameraTransform.position - lastPositionCamera;

        transform.position += new Vector3(newPos.x * multiplierEffect, 0, 0f);

        lastPositionCamera = cameraTransform.position;

        float distanceWithTheCamera = cameraTransform.position.x - transform.position.x;

        if (Mathf.Abs(distanceWithTheCamera) >= width)
        {
            var movement = distanceWithTheCamera > 0 ? width * 2f : width * -2f;
            transform.position = new Vector3(transform.position.x + movement, posY, 0f);
        }
    }
}
