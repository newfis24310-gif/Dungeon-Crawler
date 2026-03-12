using UnityEngine;
using System.Collections.Generic;

public class Map : MonoBehaviour
{
    public List<GameObject> tilePrefabs;
    [SerializeField] GameObject exittilePrefab;
    [SerializeField] GameObject emptytilePrefab;

    public int width = 5;
    public int height = 3;
    public BaseTile[,] grid;

    public GameObject tilePrefab;

    private Transform gridParent;

    void Start()
    {
        gridParent = transform;
        CreateGrid();
    }
    public void CreateGrid()
    {
        float tileZ = 0f;

        for(int j = 0; j < height; j ++)
        {
            float tileX = 0f;

            for(int i = 0; i < width; i ++)
            {
                if(i == 0 && j == 0)
                {
                    Vector3 spawnPosition = new Vector3(tileX,0,tileZ); 
                    Instantiate(emptytilePrefab,spawnPosition,Quaternion.identity,gridParent);
                    tileX += 2.3f;
                }
                else if(i == height-1 && j == width-1)
                {
                    Vector3 spawnPosition = new Vector3(tileX,0,tileZ); 
                    Instantiate(exittilePrefab,spawnPosition,Quaternion.identity,gridParent);
                    tileX += 2.3f;   
                }
                else
                {
                    Vector3 spawnPosition = new Vector3(tileX,0,tileZ); 
                    Instantiate(RandomTile(),spawnPosition,Quaternion.identity,gridParent);
                    tileX += 2.3f;   
                }
            }
            tileZ += 2.3f;
        }
        
    }

    public GameObject RandomTile()
    {
        int randomIndex = Random.Range(0, tilePrefabs.Count);
        return tilePrefabs[randomIndex];
    }
}
