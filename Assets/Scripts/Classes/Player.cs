using UnityEngine;
using System.Collections.Generic;

public class Player : Entity
{
    public InventoryComponent inventory;
    public CombatComponent combat;

    [Header("Player Stats")]
    public bool trapshield = false;
    public float moveSpeed = 5f; // units per second

    void Start()
    {
        
    }

     public void TakeDamage(int damage) //Καλεί τη μέθοδο με το ίδιο όνομα μέσα στο HealthComponent
    {
        health.TakeDamage(damage);
    }
}