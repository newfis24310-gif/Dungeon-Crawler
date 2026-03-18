using UnityEngine;

public class HealthComponent : MonoBehaviour, IComponent
{
    public int maxHP = 100;
    public int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log("Damage taken: " + damage);
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        Debug.Log("Heal taken: " + amount);
    }

    public void Death()
    {
        
    }

    public void Initialize()
    {
        maxHP = 100;
        currentHP = maxHP;
    }
}
