using UnityEngine;

[CreateAssetMenu(menuName = "Items/Vision Boost")]
public class VisionBoost : Item
{
    private GameObject obj;
    private Map map;

    public override void ExecuteEffect(Player player)
    {
        obj = GameObject.FindGameObjectWithTag("Map");
        map = obj.GetComponent<Map>();
        Use(player);
    }

    public override void Use(Player player)
    {
        map.RevealMap();
        Debug.Log("You've the eye of the eagle! You can see the whole map.");
    }
}
