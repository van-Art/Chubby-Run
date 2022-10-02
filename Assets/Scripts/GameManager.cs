using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Space]
    [Header("GameObjects")]
    public GameObject Start_Panel;
    public GameObject Win_Panel;
    public GameObject GameOver_Panel;
    public GameObject player;
    public GameObject CollectableImg;
    public GameObject pauseButton;
    public GameObject resumeButton;
    [Header("Script")]
    public Movement moveScript;
    public SpawnObs SpwObjs;
    public LevelScript lvlScrp;
    [Header("Booleans")]
    public bool GameIsPaused;

    public static GameManager instance;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Application.targetFrameRate = 120;
        //SpwObjs.enabled = GameObject.Find("SpawnObjects").GetComponent<SpawnObs>();
        //SpwObjs.enabled = false;

        lvlScrp = GetComponent<LevelScript>();

        GameIsPaused = false;

        Start_Panel.SetActive(true);
        GameOver_Panel.SetActive(false);
        player.SetActive(false);
        CollectableImg.SetActive(false);
        pauseButton.SetActive(false);
        resumeButton.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1;

            player.SetActive(true);
            Start_Panel.SetActive(false);
            SpwObjs.enabled = true;
            CollectableImg.SetActive(true);
            pauseButton.SetActive(true);
        }

        if (GameIsPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameIsPaused = true;
        }

        //Invoke("Over", .1f);
    }
    //void Over()
    //{
    //    if (FindObjectOfType<Movement>().isDead == true)
    //    {
    //        GameOver_Panel.SetActive(true);
    //        CollectableImg.SetActive(false);

    //        Destroy(pauseButton);
    //        Destroy(resumeButton);
    //    }
    //}
    public void PlayButton()
    {
        Time.timeScale = 1;
        player.SetActive(true);
        Start_Panel.SetActive(false);
        SpwObjs.enabled = true;
        CollectableImg.SetActive(true);
        pauseButton.SetActive(true);
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("Level_Selector");
    }
    public void RetryGame()
    {
        //SceneManager.LoadScene("Level1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void PauseGame()
    {
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        CollectableImg.SetActive(false);
        GameIsPaused = true;
    }
    public void Resume()
    {
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        CollectableImg.SetActive(true);
        GameIsPaused = false;
    }
}