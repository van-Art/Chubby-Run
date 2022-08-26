using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject myLevel;

    public List<GameObject> levelPrefab = new List<GameObject>();
    public List<Transform> currentLevel = new List<Transform>();

    public float offset;

    int levelIndex;

    Transform player;
    Transform currentLevelPoint;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i =0; i < levelPrefab.Count; i++)
        {
            Transform point = Instantiate(levelPrefab[i], new Vector3(0, 0, i * 39.2f), transform.rotation).transform;
            //Instantiate(levelPrefab[i], transform);
            currentLevel.Add(point);
            offset += 39.2f;
        }
        currentLevelPoint = currentLevel[levelIndex].GetComponent<Level>().point;
    }
    void Update()
    {
        float distance = player.position.z - currentLevelPoint.position.z;

        if(distance >= 5)
        {
            Recycle(currentLevel[levelIndex].gameObject);
            levelIndex++;

            if(levelIndex > currentLevel.Count - 1)
            {
                levelIndex = 0;
            }

            currentLevelPoint = currentLevel[levelIndex].GetComponent<Level>().point;
        }
    }
    public void Recycle(GameObject levels)
    {
        levels.transform.position = new Vector3(0, 0, offset);
        offset += 39.21f;
    }
}
