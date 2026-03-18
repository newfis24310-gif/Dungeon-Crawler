using UnityEngine;
using System.Collections.Generic;

public class MovementComponent : MonoBehaviour, IComponent
{
    public int playerX = 0;
    public int playerZ = 0;
    public BaseTile currentTile;
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right    
    }

    [SerializeField] Map map;

    void Start()
    {
        Debug.Log(map);
        currentTile = map.grid[0,0];
        RevealNeighbours();
    }

    public void MoveLeft()
    {
        Move(Direction.Left);
    }
    public void MoveRight()
    {
        Move(Direction.Right);
    }
    public void MoveUp()
    {
        Move(Direction.Up);
    }
    public void MoveDown()
    {
        Move(Direction.Down);
    }

   public void Move(Direction direction)
{
    int newX = playerX;
    int newZ = playerZ;

    if(direction == Direction.Left) newX--;
    if(direction == Direction.Right) newX++;
    if(direction == Direction.Up) newZ++;
    if(direction == Direction.Down) newZ--;

    if(newX < 0 || newZ < 0 || newX >= map.width || newZ >= map.height)
    {
        Debug.Log("Move blocked: out of bounds");
        return;
    }

    playerX = newX;
    playerZ = newZ;

    currentTile = map.grid[playerX, playerZ];
    transform.position = currentTile.transform.position;

    RevealNeighbours();

    TurnManager.Instance.NextState();
}


    /*void GetCurrentTile()
    {
        currentTile = map.FindCurrentTile(transform.position);
    }*/

    public void RevealNeighbours()
    {
        List<BaseTile> neighbours = map.GetNeighbours(currentTile);

        foreach(var neigh in neighbours)
        {
            neigh.shrouded = false;
            neigh.FogOff();
        }

        TurnManager.Instance.UpdateDirectionUI(neighbours, currentTile);
    }

    public void Initialize()
    {
        playerX = 0;
        playerZ = 0;
        currentTile = map.grid[0,0];
        RevealNeighbours();
    }
}
