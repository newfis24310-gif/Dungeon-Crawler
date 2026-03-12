using UnityEngine;

public abstract class BaseTile : MonoBehaviour
{
    public int x;
    public int y;
    public bool shrouded = true;

    public virtual void OnPlayerEnter(Player player)
    {
        
    }
}
