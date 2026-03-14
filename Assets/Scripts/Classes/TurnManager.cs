using UnityEngine;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;
    public enum GameState
    {
        DirectionSelection,
        PLayerMovement,
        TileAction,
        Death,
        Victory
    }
    public GameState currentState;

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
}
