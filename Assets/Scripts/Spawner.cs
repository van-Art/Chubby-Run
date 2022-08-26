using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject wall;
    public GameObject coin;

    void Start()
    {
        for(int i = 15; i < 500; i += 10)
        {
            int random = (Random.Range(0, 3) * 2) - 2;
            Instantiate(wall, new Vector3(random, 1.5f, i), new Quaternion());
        }
        for (int i = 15; i < 500; i += 5)
        {
            int random = (Random.Range(0, 3) * 2) - 2;
            Instantiate(coin, new Vector3(random, 1.5f, i + 1), coin.transform.rotation);
        }
    }
    void Update()
    {

    }
}
