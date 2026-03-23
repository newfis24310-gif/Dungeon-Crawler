using UnityEngine;

public class ExitTile : ActionTile
{
    public override void ExecuteEffect(Player player)
    {
        TurnManager.Instance.WinGame();
    }
}
