using UnityEngine;

public class HealthComponent : MonoBehaviour
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

    public void Heal()
    {
        
    }

    public void Death()
    {
        
    }

}
