using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour, IComponent
{
    [SerializeField] Slider healthBar;

    public int maxHP = 20;
    public int currentHP;
    public enum Status{Alive, Dead};
    public Status status = Status.Alive;

    void Awake()
    {
        currentHP = maxHP;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log("Damage taken: " + damage);
        if(currentHP <= 0)
        {
            Death();
        }
        UpdateHealthBar();
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        Debug.Log("Heal taken: " + amount);
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if(this.gameObject.tag == "Player")
        {
            healthBar.value = (float)currentHP/maxHP;
        }
    }

    public void Death()
    {
        status = Status.Dead;
    }

    public void Initialize()
    {
        currentHP = maxHP;
    }
}
