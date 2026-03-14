using UnityEngine;
using System.Collections.Generic;

public class Map : MonoBehaviour
{
    [SerializeField] GameObject exitTilePrefab;
    [SerializeField] GameObject emptyTilePrefab;

    [Header("Map Dimensions")]
    public int width = 5;
    public int height = 3;
    public float tileSize = 2.3f;

    public BaseTile[,] grid;
    private Transform gridParent;

    public List<GameObject> tilePrefabs;

    void Start()
    {
        gridParent = transform;
        grid = new BaseTile[width,height];
        CreateGrid();
    }

    private void CreateGrid()
    {
        for(int x=0; x<grid.GetLength(0); x++)
        {
            for(int z=0; z<grid.GetLength(1); z++)
            {
                if(x == 0 && z == 0)
                {
                    BaseTile tile = Instantiate(emptyTilePrefab,GetTilePosition(x,z),Quaternion.identity,gridParent).GetComponent<BaseTile>();
                    tile.x = x; //Update tile class coordinates
                    tile.z = z;
                    grid[x,z] = tile;
                }
                else if(x == grid.GetLength(0)-1 && z == grid.GetLength(1)-1)
                {
                    BaseTile tile = Instantiate(exitTilePrefab,GetTilePosition(x,z),Quaternion.identity,gridParent).GetComponent<BaseTile>();
                    tile.x = x;
                    tile.z = z;
                    grid[x,z] = tile;  
                }
                else
                {
                    BaseTile tile = Instantiate(RandomTile(),GetTilePosition(x,z),Quaternion.identity,gridParent).GetComponent<BaseTile>();
                    tile.x = x;
                    tile.z = z;
                    grid[x,z] = tile;   
                }
            }
        }
    }

    private Vector3 GetTilePosition(int x, int z)
    {
        return new Vector3(x,0,z) * tileSize;
    }

    private GameObject RandomTile()
    {
        int randomIndex = Random.Range(0, tilePrefabs.Count);
        return tilePrefabs[randomIndex];
    }

    public List<BaseTile> GetNeighbours(BaseTile tile)
    {
        List<BaseTile> neighbours = new List<BaseTile>();
        Vector2Int[] directions =
        {
        new Vector2Int(0,1),  //Up
        new Vector2Int(0,-1), //Down
        new Vector2Int(-1,0), //Left
        new Vector2Int(1,0) //Right
        };

        foreach(var dir in directions)
        {
            int neighX = tile.x + dir.x;
            int neighZ = tile.z + dir.y;
            if(IsInsideGrid(neighX,neighZ))
            {
                neighbours.Add(grid[neighX,neighZ]);
            }
        }
        return neighbours;
    }

    private bool IsInsideGrid(int x, int z)
    {
        return x>=0 && x<width && z>=0 && z<height;
    }
}
