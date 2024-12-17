using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private int maxHealth;
    private int currentHealth;

    public HealthSystem(int health)
    {
        maxHealth = health;
        currentHealth = health;
    }
    public int getHealth() => currentHealth;
    public int getMaxHealth() => maxHealth;

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0)
            currentHealth = 0;
    }
    public void heal(int amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    public bool isDead() => currentHealth <= 0;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
