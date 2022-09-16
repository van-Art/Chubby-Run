using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Start_Panel;
    public GameObject GameOver_Panel;
    public GameObject PauseButton;
    public GameObject ResumeButton;
    public GameObject SpwObjs;
    public GameObject player;


    public static bool GameIsPaused = false;

    public static GameManager instance;
    void Start()
    {
        instance = this;
        player.SetActive(false);
        Start_Panel.SetActive(true);
        //PauseButton.SetActive(false);
        ResumeButton.SetActive(false);
        SpwObjs.SetActive(false);
        GameOver_Panel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            player.SetActive(true);
            Start_Panel.SetActive(false);
            SpwObjs.SetActive(true);
            //PauseButton.SetActive(true);
        }
        Resume();
    }
    public void PlayButton()
    {
        player.SetActive(true);
        Start_Panel.SetActive(false);
        SpwObjs.SetActive(true);
        //PauseButton.SetActive(true);
    }
    public void RetryGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void PauseGame()
    {
        //if (GameIsPaused)
        //    Resume();
        //else
        //    Pause();
        Pause();
    }
    public void Resume()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("escape");
            Time.timeScale = 1f;
            GameIsPaused = false;
        }
        Time.timeScale = 1f;
        GameIsPaused = false;
        ResumeButton.SetActive(false);
        PauseButton.SetActive(true);
    }
    void Pause()
    {
        
        Time.timeScale = 0f;
        GameIsPaused = true;
        ResumeButton.SetActive(true);
        PauseButton.SetActive(false);
    }
}
