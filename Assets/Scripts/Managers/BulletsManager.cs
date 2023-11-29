using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsManager : MonoBehaviour
{
    public static BulletsManager instance;

    public PlayerShoot shootComponent;
    public Action<int> bulletsModified;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddBullets(int amount)
    {
        if (shootComponent != null)
        {
            shootComponent.bullets += amount;
            bulletsModified.Invoke(shootComponent.bullets);
        }
    }

    public void RemoveBullets(int amount)
    {
        if (shootComponent != null)
        {
            shootComponent.bullets -= amount;
            bulletsModified.Invoke(shootComponent.bullets);
        }
    }
}
