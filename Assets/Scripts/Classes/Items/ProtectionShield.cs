using UnityEngine;

[CreateAssetMenu(menuName = "Items/Shield")]
public class ProtectionShield : Item
{
    public override void Use(Player player)
    {
        ExecuteEffect(player);
    }

    override public void ExecuteEffect(Player player)
    {
        player.trapshield=true;
        Debug.Log("You got a shield! Next trap, you will be protected.");
    }
}
