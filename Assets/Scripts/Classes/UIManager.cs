using System.Runtime.Serialization;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject dirMenu;
    [SerializeField] GameObject healthBar;
    [SerializeField] GameObject winMessage;
    [SerializeField] GameObject loseMessage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void EnableDirectionUI()
    {
        dirMenu.SetActive(true);
    }

    public void DisableDirectionUI()
    {
        dirMenu.SetActive(false);
    }

    public void EnableWinMessage()
    {
        healthBar.SetActive(false);
        winMessage.SetActive(true);
    }

    public void EnableLoseMessage()
    {
        healthBar.SetActive(false);
        loseMessage.SetActive(true);
    }
}
