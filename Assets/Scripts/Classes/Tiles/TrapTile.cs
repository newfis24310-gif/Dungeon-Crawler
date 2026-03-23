using UnityEngine;

public class TrapTile : ActionTile
{
    public int damage = 10;

    public override void ExecuteEffect(Player player)
    {
        if(traversed == false)
        {
            var playerHealth = player.GetComponent<HealthComponent>();

            playerHealth.TakeDamage(damage);
            Debug.Log($"It's a trap! How unfortunate... You took {damage} damage.");
            traversed = true;
            if(playerHealth.status == HealthComponent.Status.Dead)
            {
                TurnManager.Instance.LoseGame();
            }
        }
        EndEffect();
    }
}