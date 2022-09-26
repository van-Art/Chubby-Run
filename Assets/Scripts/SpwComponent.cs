using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwComponent : MonoBehaviour
{
    bool isSpawned = false;
    [SerializeField]
    Transform spwPoint1;

    [SerializeField]
    GameObject CompObj1;
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
                Instantiate(CompObj1, spwPoint1);
                isSpawned = true;
                Debug.Log("Instanted");
            }
        }
    }
}
