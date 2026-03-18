using System.Runtime.Serialization;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject dirMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void EnableDirectionUI()
    {
        dirMenu.SetActive(true);
    }

    public void DisableDirectionUI()
    {
        dirMenu.SetActive(false);
    }
}
