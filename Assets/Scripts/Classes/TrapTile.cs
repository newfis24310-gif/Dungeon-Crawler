using UnityEngine;

public class TrapTile : ActionTile
{
    public int damage = 10;

    public override void OnPlayerEnter(Player player)
    {
        player.TakeDamage(damage);
    }
}
