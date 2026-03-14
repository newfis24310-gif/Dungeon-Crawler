using UnityEngine;

public class Detector : MonoBehaviour
{
    public bool moveselection = false;
    public GameObject directionmessage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Floor") && moveselection == true)
        {
            directionmessage.SetActive(true);
        }
        if(other.CompareTag("Fog"))
        {
            other.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Floor") && moveselection == true)
        {
            directionmessage.SetActive(false);
        }
    }
}
