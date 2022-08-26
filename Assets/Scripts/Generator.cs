using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public List<GameObject> levelPrefab = new List<GameObject>();

    public int offset;

    void Start()
    {
        for(int i =0; i < levelPrefab.Count; i++)
        {
            Instantiate(levelPrefab[i], new Vector3(0, 0, i * 40.1f), transform.rotation);
        }
    }
    void Update()
    {
        
    }
    void Recycle(GameObject levels)
    {

    }
}
