using UnityEngine;

public abstract class BaseTile : MonoBehaviour, IEffect
{
    public int x;
    public int z;
    public bool shrouded = true;
    public bool traversed = false;
    public GameObject fog;

    void Awake()
    {
        Transform childTransform = transform.Find("Fog");
        fog = childTransform.gameObject;
    }

    public void FogOff()
    {
        fog.SetActive(false);
    }

    public virtual void ExecuteEffect(Player player){}

    public void EndEffect()
    {
        TurnManager.Instance.NextState();
    }
}
