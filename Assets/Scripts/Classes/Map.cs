using UnityEngine;
using System.Collections.Generic;

public class Map : MonoBehaviour
{
    public List<GameObject> tilePrefabs;
    [SerializeField] GameObject exittilePrefab;
    [SerializeField] int Xtiles =1;
    [SerializeField] int Ztiles =1;
    private Transform gridParent;

    void Start()
    {
        gridParent = transform;
        CreateGrid(Xtiles,Ztiles);
    }
    public void CreateGrid(int x,int z)
    {
        float tileZ = 0f;

        for(int j = 0; j < z; j ++)
        {
            float tileX = 0f;

            for(int i = 0; i < x; i ++)
            {
                if(i == x-1 && j == z-1)
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
