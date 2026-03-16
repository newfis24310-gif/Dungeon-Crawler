using UnityEngine;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;
    public Map map;
    public Player player;
    public GameObject LeftOption, RightOption, UpOption, DownOption;

    public bool Right,Left,Up,Down = false;
    public enum GameState
    {
        DirectionSelection,
        PLayerMovement,
        TileAction,
        Death,
        Victory
    }
    public GameState currentState;

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
                currentState = GameState.PLayerMovement;
                break;
            
            case GameState.PLayerMovement:
                currentState = GameState.TileAction;
                break;
        }
    }

    public void TurnOnDirections(List<BaseTile> neighbours)
    {
        if(Left){LeftOption.SetActive(true);}
        if(Right){RightOption.SetActive(true);}
        if(Up){UpOption.SetActive(true);}
        if(Down){DownOption.SetActive(true);}
    }
    }
