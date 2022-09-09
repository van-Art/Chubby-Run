using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Start_Panel;
    public GameObject GameOver_Panel;
    public GameObject SpwObjs;
    public GameObject player;

    public static GameManager instance;
    void Start()
    {
        instance = this;
        player.SetActive(false);
        Start_Panel.SetActive(true);
        SpwObjs.SetActive(false);
        GameOver_Panel.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            player.SetActive(true);
            Start_Panel.SetActive(false);
            SpwObjs.SetActive(true);
        }
    }
    public void PlayButton()
    {
        player.SetActive(true);
        Start_Panel.SetActive(false);
        SpwObjs.SetActive(true);
    }
    public void RetryGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
