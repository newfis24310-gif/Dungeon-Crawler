using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour, IComponent
{
    public List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public void UseItem(Item item, Player player)
    {
        item.Use(player);
    }

    public void Initialize()
    {
        items = new List<Item>();
    }
}
