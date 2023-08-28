using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] private int health = 10;

    public int ApplyDamage(int value)
    {
        health -= value;

        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }

        return health;
    }

    public int GetHealth()
    {
        return health;
    }

    public int HealPlayer(int value)
    {
        health += value;
        
        if (health > 100)
        {
            health = 100;
        }

        return health;
    }
}
