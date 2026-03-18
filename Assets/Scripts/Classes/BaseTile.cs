using UnityEngine;

public abstract class BaseTile : MonoBehaviour, IEffect
{
    public int x;
    public int z;
    public bool shrouded = true;
    public GameObject fog;
    public TurnManager turnManager;

    void Awake()
    {
        Transform childTransform = transform.Find("Fog");
        fog = childTransform.gameObject;
    }
    public virtual void OnPlayerEnter(Player player){}

    public void FogOff()
    {
        fog.SetActive(false);
    }

    public virtual void ExecuteEffect(){}
    public virtual void EndEffect()
    {
        turnManager.NextState();
    }
}
