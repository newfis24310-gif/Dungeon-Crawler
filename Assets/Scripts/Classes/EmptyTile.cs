using UnityEngine;

public class EmptyTile : BaseTile
{
    public override void ExecuteEffect()
    {
        Debug.Log("This tile is Empty. Yoy can go on now. Come on, don't be scared.");
        EndEffect();
    }
}
