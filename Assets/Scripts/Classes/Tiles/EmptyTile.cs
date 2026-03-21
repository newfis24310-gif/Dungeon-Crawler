using UnityEngine;

public class EmptyTile : BaseTile
{
    public override void ExecuteEffect(Player player)
    {
        if(traversed == false)
        {
            Debug.Log("This tile is Empty. Yoy can go on now. Come on, don't be scared.");
            traversed = true;
        }
        EndEffect();
    }
}
