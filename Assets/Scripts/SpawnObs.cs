using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObs : MonoBehaviour
{
    public Transform[] Points;

    public GameObject[] obs;

    int randObs;
    int randPoints;
    void Start()
    {
        for(int i = 0; i < Points.Length; i++)
        {
            randObs = Random.Range(0, obs.Length);
            Instantiate(obs[randObs], Points[i]);
        }
    }
    void Update()
    {
        
    }
    public void Instante()
    {
        
        randPoints = Random.Range(0, Points.Length);
        Instantiate(obs[randObs], Points[randPoints]);
    }
}
