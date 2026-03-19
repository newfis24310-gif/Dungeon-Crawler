using UnityEngine;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;
    public Map map;
    public Player player;
    public GameObject LeftOption, RightOption, UpOption, DownOption;
    public enum GameState
    {
        DirectionSelection,
        TileAction,
        Death,
        Victory
    }
    public GameState currentState;

    [SerializeField] UIManager uiManager;

    private void Awake()
    {
        // Ensure singleton
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    
    void Start()
    {
        currentState = GameState.DirectionSelection;
    }

    public void NextState()
    {
        switch(currentState)
        {
            case GameState.DirectionSelection:
                currentState = GameState.TileAction;
                uiManager.DisableDirectionUI();
                player.GetComponent<MovementComponent>().currentTile.ExecuteEffect();
                break;
            
            case GameState.TileAction:
                currentState = GameState.DirectionSelection;
                uiManager.EnableDirectionUI();
                break;
        }
    }

    public void UpdateDirectionUI(List<BaseTile> neighbours, BaseTile currentTile)
    {
        LeftOption.SetActive(false);
        RightOption.SetActive(false);
        UpOption.SetActive(false);
        DownOption.SetActive(false);

        foreach(var neigh in neighbours)
        {
            int dx = neigh.x - currentTile.x;
            int dz = neigh.z - currentTile.z;

            if(dx == -1) LeftOption.SetActive(true);
            if(dx == 1) RightOption.SetActive(true);
            if(dz == 1) UpOption.SetActive(true);
            if(dz == -1) DownOption.SetActive(true);
        }
    }
    }
