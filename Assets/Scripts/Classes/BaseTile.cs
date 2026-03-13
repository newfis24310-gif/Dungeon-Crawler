using UnityEngine;

public abstract class BaseTile : MonoBehaviour
{
    public int x;
    public int z;
    public bool shrouded = true;

    void Start()
    {
        Debug.Log(x + "," + z);
    }
    public virtual void OnPlayerEnter(Player player)
    {
        
    }
}
