using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;

    public GameObject[] LevelPrefab;
    List<GameObject> levels = new List<GameObject>();
    public float maxSpeed = 10;

    float speed = 0;
    public int maxRoadCount = 5;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ResetLevel();
        StartLevel();
    }
    void Update()
    {
        LevelGen();
    }
    void LevelGen()
    {
        if (speed == 0)
            return;
        foreach (GameObject level in levels)
        {
            level.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        }
        if (levels[0].transform.position.z < -20)
        {
            Destroy(levels[0]);
            levels.RemoveAt(0);

            CreateNextLevel();
        }
        //CreateNextLevel();
    }
    void StartLevel()
    {
        speed = maxSpeed;
    }
    void CreateNextLevel()
    {
        int index = Random.Range(0, LevelPrefab.Length);
        Vector3 pos = Vector3.zero;
        if(levels.Count > 0)
        {
            pos = levels[levels.Count - 1].transform.position + new Vector3(0, 0, 40);
        }
        GameObject go = Instantiate(LevelPrefab[index], pos, Quaternion.identity);
        go.transform.SetParent(transform);
        levels.Add(go);
    }
    void ResetLevel()
    {
        speed = 0;
        while (levels.Count > 0)
        {
            Destroy(levels[0]);
            levels.RemoveAt(0);
        }
        for (int i = 0; i < maxRoadCount; i++)
        {
            CreateNextLevel();
        }
    }
}
