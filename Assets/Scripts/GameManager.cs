using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject level1;
    void Start()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Chubby_run_level"))
        {
            level1.SetActive(false);
        }
    }
    void Update()
    {
        
    }
}
