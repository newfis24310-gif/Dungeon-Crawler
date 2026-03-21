using UnityEngine;

public class CombatTile : ActionTile
{
    CombatComponent combatComponent;

    public override void ExecuteEffect(Player player)
    {
        if(traversed == false)
        {
            Debug.Log("Oh no! You've entered combat.");
            combatComponent = player.GetComponent<CombatComponent>();
            combatComponent.PrepareCombat();
            traversed = true;
        }
    }
}
