using UnityEngine;

public class Item : ScriptableObject, IUsable, IEffect
{
    public string itemName; 
    public GameObject inventory;

    virtual public void ExecuteEffect(Player player){}
    public virtual void Use(Player player){}
}
