using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public enum SpecialOptions
    {
        Player,
        Boss,
        None
    }

    [SerializeField] private int health = 10;
    public int maxHealth;
    public SpecialOptions specialOptions = SpecialOptions.None;
    public string specialOptionsParams;

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

            if (specialOptions == SpecialOptions.Player)
            {
                GameManager.instance.playerDeath.Invoke();
            } else
            {
                if (specialOptions == SpecialOptions.Boss)
                {
                    GameManager.instance.levelCompleted.Invoke(specialOptionsParams);
                }

                Destroy(gameObject);
            }
        }

        return health;
    }

    public int GetHealth()
    {
        return health;
    }

    public bool Heal(int value)
    {
        if (specialOptions != SpecialOptions.Player) return false;

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
