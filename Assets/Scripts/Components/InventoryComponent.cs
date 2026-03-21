using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryComponent : MonoBehaviour, IComponent
{
    public List<Item> items = new List<Item>();
    public List<Item> equipedItems = new List<Item>();
    public GameObject inventoryPanel, healthPotionButton;
    private Item generatedItem;

    public void RandomItem()
    {
        Debug.Log("Random Item");
        int randomIndex = UnityEngine.Random.Range(0, items.Count);
        generatedItem = items[randomIndex];
        generatedItem.ExecuteEffect(gameObject.GetComponent<Player>());
    }

    public void AddItem(Item item)
    {
        equipedItems.Add(generatedItem);
        inventoryPanel.SetActive(true);
        if(generatedItem.GetType() == typeof(HealthPotion))
        {
            healthPotionButton.SetActive(true);
        }
    }

    public void UseHealthPotion()
    {
        UseItem(FindItemInList("Health Potion"), gameObject.GetComponent<Player>());
    }

    private Item FindItemInList(string name)
    {
        return equipedItems.FirstOrDefault(i => i.itemName == name);
    }

    public void UseItem(Item item, Player player)
    {
        Item itemToUse = equipedItems.FirstOrDefault(i => i.GetType() == item.GetType());
        itemToUse.Use(player);
        RemoveItem(itemToUse);
    }

    private void RemoveItem(Item item)
    {
        equipedItems.Remove(item);
        if(item.GetType() == typeof(HealthPotion))
        {
            healthPotionButton.SetActive(false);
        }
        if(equipedItems.Count == 0)
        {
            inventoryPanel.SetActive(false);
        }
    }

    public void Initialize()
    {
        items = new List<Item>();
    }    
}
