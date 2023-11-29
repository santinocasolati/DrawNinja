using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private bool canShoot = true;
    private float currentShootTime;
    [SerializeField] private float shootTime = 0.3f;
    public GameObject shootPosition;
    [SerializeField] private AudioClip shootSound;
    public int bullets = 15;

    private void Awake()
    {
        BulletsManager.instance.shootComponent = this;
        BulletsManager.instance.AddBullets(0);
    }

    void CheckInputs()
    {
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

    void Shoot()
    {
        if (bullets == 0) return;
        canShoot = false;
        currentShootTime = 0;
        Instantiate(bulletPrefab, shootPosition.transform.position, transform.rotation);
        AudioManager.instance.PlaySound(shootSound);
        BulletsManager.instance.RemoveBullets(1);
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
        CheckInputs();
    }

    private void FixedUpdate()
    {
        //Debug.Log($"currentKnockbackTime:{(int)currentKnockbackTime}");
        //Debug.Log($"knockTime:{knockTime}");
    }
}
