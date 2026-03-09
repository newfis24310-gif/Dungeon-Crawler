using UnityEngine;

public class Player : Entity
{
    public bool trapshield = false;
    public float moveSpeed = 5f; // units per second
    [SerializeField] Game gamemanager;
    public void MoveLeft()
    {
        Vector3 targetposition = transform.position;

        gamemanager.NextState();
        targetposition += new Vector3(-2.3f,0,0);
        transform.position = targetposition;
    }

    public void MoveRight()
    {
        Vector3 targetposition = transform.position;

        gamemanager.NextState();
        targetposition += new Vector3(2.3f,0,0);
        transform.position = targetposition;
    }

    public void MoveUp()
    {
        Vector3 targetposition = transform.position;

        gamemanager.NextState();
        targetposition += new Vector3(0,0,2.3f);
        transform.position = targetposition;
    }

    public void MoveDown()
    {
        Vector3 targetposition = transform.position;

        gamemanager.NextState();
        targetposition += new Vector3(0,0,-2.3f);
        transform.position = targetposition;
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Fog"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
