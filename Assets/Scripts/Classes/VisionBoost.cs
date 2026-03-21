using UnityEngine;

public class VisionBoost : Item
{
    private GameObject obj;
    private Map map;

    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("Map");
        map = obj.GetComponent<Map>();
    }

    public override void ExecuteEffect(Player player)
    {
        map.RevealMap();
    }
}
