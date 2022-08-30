using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform point;
    public Transform[] spwPoints;

    public GameObject[] Obstacles;
    public GameObject[] Enemies;

    GameObject CurrentObs;
    GameObject CurrentEnemy;

    int rand;
    int randPoint;
    void Start()
    {
        //SpawnObs();
        SpawnEnemies();
    }
    public void SpawnObs()
    {
        if (CurrentObs != null)
            Destroy(CurrentObs);
        rand = Random.Range(0, Obstacles.Length);
        CurrentObs = Instantiate(Obstacles[rand], transform);
    }
    public void SpawnEnemies()
    {
        if (CurrentEnemy != null)
            Destroy(CurrentEnemy);
        rand = Random.Range(0, Enemies.Length);
        randPoint = Random.Range(0, spwPoints.Length);
        CurrentEnemy = Instantiate(Enemies[rand], spwPoints[randPoint]);
    }
}
