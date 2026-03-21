using UnityEngine;

public class HealthPotion : Item
{
    [SerializeField] int healAmount = 10;

    virtual public void ExecuteEffect(Player player)
    {
        inventory.SetActive(true);
    }

    public void Use(Player player)
    {
        HealthComponent health = player.GetComponent<HealthComponent>();
        health.Heal(healAmount);
    }
}
