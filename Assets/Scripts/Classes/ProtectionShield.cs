using UnityEngine;

public class ProtectionShield : Item, IUsable
{
    public void Collect(Player player)
    {
        player.inventory.AddItem(this);
    }

    public void Use(Player player)
    {
        ExecuteEffect(player);
    }

    override public void ExecuteEffect(Player player)
    {
        player.trapshield=true;
        Debug.Log("You got shield!");
    }
}
