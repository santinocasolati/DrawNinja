using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private GameObject bulletPrefab;

    public bool gameStarted;

    private bool canShoot = true;
    private float currentShootTime;
    [SerializeField] private float shootTime = 0.25f;
    public GameObject shootPosition;

    void KeyActions()
    {
        if (gameStarted)
        {
            Move();

            if (Input.GetButton("Fire1"))
            {
                if (canShoot)
                {
                    Shoot();
                }
            }

            if (!canShoot)
            {
                ShootReset();
            }
        }
    }

    void Move()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        transform.Translate(transform.right * horizontalAxis * Time.deltaTime * velocity);

        Vector3 rotation = transform.rotation.eulerAngles;
        if (horizontalAxis > 0)
        {
            rotation.y = 0;
        } else if (horizontalAxis < 0)
        {
            rotation.y = 180;
        }

        transform.rotation = Quaternion.Euler(rotation);
    }

    void Shoot()
    {
        canShoot = false;
        currentShootTime = 0;
        Instantiate(bulletPrefab, shootPosition.transform.position, transform.rotation);
    }

    void ShootReset()
    {
        currentShootTime += Time.deltaTime;

        if (currentShootTime >= shootTime)
        {
            canShoot = true;
        }
    }
    
    void Update()
    {
        KeyActions();
    }
}
