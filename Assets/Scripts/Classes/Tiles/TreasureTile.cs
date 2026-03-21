using UnityEngine;
using System.Collections.Generic;

public class TreasureTile : ActionTile
{
    public override void ExecuteEffect(Player player)
    {
        if(traversed == false)
        {
            InventoryComponent inventoryComponent = player.GetComponent<InventoryComponent>();
            inventoryComponent.RandomItem();
            traversed = true;
        }
        EndEffect();
    }
}
