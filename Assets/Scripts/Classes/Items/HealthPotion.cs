using UnityEngine;

[CreateAssetMenu(menuName = "Items/Healing Potion")]
public class HealthPotion : Item, ICollectible
{
    public int healAmount = 10;

    override public void ExecuteEffect(Player player)
    {
        Collect(player);
        Debug.Log("You got a health potion! You can choose to drink it to regenerate 10 HP.");
    }

    public void Collect(Player player)
    {
        InventoryComponent inventoryComponent = player.GetComponent<InventoryComponent>();
        inventoryComponent.AddItem(this);
    }

    public override void Use(Player player)
    {
        HealthComponent health = player.GetComponent<HealthComponent>();
        health.Heal(healAmount);
        Debug.Log($"You healed {healAmount} HP!");
    }
}
