using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] private int health = 10;
    private int maxHealth;

    private void Awake()
    {
        maxHealth = health;
    }

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

    public int Heal(int value)
    {
        health += value;
        
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        return health;
    }
}
