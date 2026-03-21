using UnityEngine;

public class TrapTile : ActionTile
{
    public int damage = 10;

    public virtual void ExecuteEffect(Player player)
    {
        player.TakeDamage(damage);
    }
}
