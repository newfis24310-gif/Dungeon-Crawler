using UnityEngine;

public class HealthComponent : MonoBehaviour, IComponent
{
    public int maxHP = 20;
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
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        Debug.Log("Heal taken: " + amount);
    }

    public void Death()
    {
        
    }

    public void Initialize()
    {
        currentHP = maxHP;
    }
}
