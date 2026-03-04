using UnityEngine;

public class ProtectionShield : Item
{   private Player player;
    void Start()
    {
        GameObject targetObject = GameObject.FindGameObjectWithTag("Player");
        player= targetObject.GetComponent<Player>();
    }
    override public void ExecuteEffect()
    {
        player.trapshield=true;
        Debug.Log("You got shield!");
    }
}
