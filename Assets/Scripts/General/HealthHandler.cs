using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] private int health = 10;
    public int maxHealth;

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

    public bool Heal(int value)
    {
        bool canHeal = true;
        health += value;
        
        if (health > maxHealth)
        {
            health = maxHealth;
            canHeal = false;
        }

        return canHeal;
    }
}
