using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] protected HealthBar healthBar;
    [SerializeField] private CharacterData data;
    private static int dead = 0;
    public float MaxHealth => data.maxHealth;
    public float CurrentHealth => data.currentHealth;
    // current health of a player or enemy
    protected float health;
    protected int countDeath = 0;
    // id of a player or enemy
    public int id;
    private void OnValidate() => healthBar = GetComponentInChildren<HealthBar>();
    private void Start()
    {
        healthBar.SetMaxHealth(MaxHealth);
        health = CurrentHealth;
        healthBar.SetInitialHealth(health);
    }
    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        if (health <= 0) Die();
    }
    protected virtual void Die()
    {
        GameEvent.Instance.FirstBlood(id);
        GameEvent.Instance.Death(id);
        Destroy(gameObject);
    }
}
