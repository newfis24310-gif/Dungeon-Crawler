using UnityEngine;

public class Item : MonoBehaviour
{
    string itemName;
    public GameObject inventory;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory");
    }

    virtual public void ExecuteEffect(Player player){}

    public void Use(Player player){}
}
