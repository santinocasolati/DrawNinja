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

    [SerializeField] FloatingHPBar hpBar;

    private void Start()
    {
        maxHealth = health;

        if (specialOptions == SpecialOptions.Player)
        {
            ScoreManager.instance.healthChanged.Invoke(health);
        }

        if (specialOptions == SpecialOptions.Boss)
        { 
            hpBar.UpdateHPBar(health, maxHealth);
        }
    }

    private void Awake()
    {
        hpBar = GetComponentInChildren<FloatingHPBar>();
    }
    public int ApplyDamage(int value)
    {
        health -= value;

        if (specialOptions == SpecialOptions.Player)
        {
            ScoreManager.instance.healthChanged.Invoke(health);
        }

        if (specialOptions == SpecialOptions.Boss)
        {
            hpBar.UpdateHPBar(health, maxHealth);
        }

        if (health <= 0)
        {
            health = 0;

            if (specialOptions == SpecialOptions.Player)
            {
                GameManager.instance.playerDeath.Invoke();
            } else
            {
                int scoreAdded = 1;

                if (specialOptions == SpecialOptions.Boss)
                {
                    GameManager.instance.levelCompleted.Invoke(specialOptionsParams);
                    scoreAdded = 10;
                }

                ScoreManager.instance.scoreChanged.Invoke(scoreAdded);

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

        ScoreManager.instance.healthChanged.Invoke(health);

        return canHeal;
    }
}
