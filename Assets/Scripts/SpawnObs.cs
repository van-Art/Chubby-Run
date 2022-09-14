using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObs : MonoBehaviour
{
    public Transform[] allPoints;
    public GameObject[] obs;

    int rand;
    void Start()
    {
        for(int i = 0; i < allPoints.Length; i++)
        {
            rand = Random.Range(0, obs.Length);
            Instantiate(obs[rand], allPoints[i]);
        }
    }
    void Update()
    {
        
    }
}
