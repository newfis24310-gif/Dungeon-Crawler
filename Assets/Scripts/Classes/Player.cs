using UnityEngine;
using System.Collections.Generic;

public class Player : Entity
{
    public InventoryComponent inventory;
    public CombatComponent combat;


    [SerializeField] Map map;
    public BaseTile currentTile;

    [Header("Player Stats")]
    public bool trapshield = false;
    public float moveSpeed = 5f; // units per second


    void Start()
    {
        currentTile = map.grid[0,0];
        RevealNeighbours();
    }

     public void TakeDamage(int damage) //Καλεί τη μέθοδο με το ίδιο όνομα μέσα στο HealthComponent
    {
        health.TakeDamage(damage);
    }

    public void MoveLeft()
    {
        Vector3 targetposition = transform.position;

        TurnManager.Instance.NextState();
        targetposition += new Vector3(-2.3f,0,0);
        transform.position = targetposition;
        GetCurrentTile();
        RevealNeighbours();
    }

    public void MoveRight()
    {
        Vector3 targetposition = transform.position;

        TurnManager.Instance.NextState();
        targetposition += new Vector3(2.3f,0,0);
        transform.position = targetposition;
        GetCurrentTile();
        RevealNeighbours();
    }

    public void MoveUp()
    {
        Vector3 targetposition = transform.position;

        TurnManager.Instance.NextState();
        targetposition += new Vector3(0,0,2.3f);
        transform.position = targetposition;
        GetCurrentTile();
        RevealNeighbours();
    }

    public void MoveDown()
    {
        Vector3 targetposition = transform.position;

        TurnManager.Instance.NextState();;
        targetposition += new Vector3(0,0,-2.3f);
        transform.position = targetposition;
        GetCurrentTile();
        RevealNeighbours();
    }

    void GetCurrentTile()
    {
        currentTile = map.FindCurrentTile(transform.position);
    }

    public void RevealNeighbours()
    {
        List<BaseTile> neighbours = new List<BaseTile>(map.GetNeighbours(currentTile));

        foreach(var neigh in neighbours)
        {
            neigh.shrouded = false;
            neigh.FogOff();
        }
        if(TurnManager.Instance.currentState == TurnManager.GameState.DirectionSelection)
        {
            TurnManager.Instance.TurnOnDirections(neighbours);
        }
    }
}
