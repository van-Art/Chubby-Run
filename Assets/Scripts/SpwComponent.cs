using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwComponent : MonoBehaviour
{
    bool isSpawned = false;
    public Transform spwPoint;

    public GameObject CompObj;
    void Start()
    {
        isSpawned = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (isSpawned == false)
            {
                Instantiate(CompObj, spwPoint);
                Debug.Log("Instantiated");
                Debug.Log(transform.position);
                isSpawned = true;
            }
        }
    }
}
