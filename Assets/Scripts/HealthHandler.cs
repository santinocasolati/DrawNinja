using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] private int health = 100;

    int ApplyDamage(int value)
    {
        health -= value;

        if (health < 0)
        {
            health = 0;
        }

        return health;
    }

    int GetHealth()
    {
        return health;
    }

    int HealPlayer(int value)
    {
        health += value;
        
        if (health > 100)
        {
            health = 100;
        }

        return health;
    }
}
