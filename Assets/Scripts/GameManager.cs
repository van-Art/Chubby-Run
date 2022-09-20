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
    public SpawnObs SpwObjs;
    [Header("UI: Start Panel")]
    public TMP_Text ComponentText;
    public int compScore = 0;
    public TMP_Text TomatoText;
    public int tomatoScore = 0;
    public TMP_Text MorolText;
    public int morolScore = 0;
    public TMP_Text OnionText;
    public int onionScore = 0;
    [Header("UI: Win Panel")]
    public TMP_Text lettuceText;
    [Header("Booleans")]
    public bool GameIsPaused;

    public static GameManager instance;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        SpwObjs.enabled = GameObject.Find("SpawnObjects").GetComponent<SpawnObs>();
        SpwObjs.enabled = false;

        GameIsPaused = false;

        ComponentText.text = "0";
        MorolText.text = "0";

        Start_Panel.SetActive(true);
        GameOver_Panel.SetActive(false);
        player.SetActive(false);
        CollectableImg.SetActive(false);
        pauseButton.SetActive(false);
        resumeButton.SetActive(false);
    }
    void Update()
    {
        if(Movement.mInstance.isDone == true)
        {
            lettuceText.text = MorolText.text;
        }
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
    }
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
        SceneManager.LoadScene("Level1");
    }
    public void PauseGame()
    {
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        GameIsPaused = true;
    }
    public void Resume()
    {
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        GameIsPaused = false;
    }
    public void addComponentCount()
    {
        ComponentText.text = "" + compScore;

        if(Movement.mInstance.isTaken == true)
        {
            compScore = compScore + 1;
            ComponentText.text = "" + compScore;
        }
    }
    public void addLettuceCount()
    {
        MorolText.text = "" + morolScore;
        if (Movement.mInstance.isTakenMorol == true)
        {
            morolScore += 1;
            MorolText.text = "" + morolScore;
        }
    }
}
