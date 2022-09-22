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
    [Header("UI: Score")]
    public int pattScore = 0;
    public int tomatoScore = 0;
    public int morolScore = 0;
    public int onionScore = 0;
    [Header("UI: CollectablesText")]
    public TMP_Text PattyCollectableText;
    public TMP_Text TomatoCollectableText;
    public TMP_Text MorolCollectableText;
    public TMP_Text OnionCollectableText;
    [Header("UI: Start Panel")]
    public TMP_Text PattyText;
    public TMP_Text TomatoText;
    public TMP_Text MorolText;
    public TMP_Text OnionText;
    [Header("UI: Win Panel")]
    public TMP_Text lettuceText;
    public TMP_Text oniText;
    public TMP_Text pattyText;
    public TMP_Text tomatText;
    [Header("UI: GameOver Panel")]
    public TMP_Text overLettuceText;
    public TMP_Text overOniText;
    public TMP_Text overPattyText;
    public TMP_Text overTomatText;
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

        PattyText.text = "0";
        MorolText.text = "0";
        OnionText.text = "0";
        TomatoText.text = "0";

        //Collectable Objects Text equal Start text
        PattyCollectableText.text = PattyText.text;
        MorolCollectableText.text = MorolText.text;
        TomatoCollectableText.text = TomatoText.text;
        OnionCollectableText.text = OnionText.text;

        MorolCollectableText.text = PlayerPrefs.GetInt("MorolHighScore", 0).ToString();

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
            //Win panel text equal to start panel text
            lettuceText.text = MorolText.text;
            oniText.text = OnionText.text;
            tomatText.text = TomatoText.text;
            pattyText.text = PattyText.text;
        }
        if(Movement.mInstance.isDead == true)
        {
            //Game over panel text equal to start panel
            overLettuceText.text = MorolText.text;
            overOniText.text = OnionText.text;
            overPattyText.text = PattyText.text;
            overTomatText.text = TomatoText.text;
        }
        //playerprefs save collected count
        if(morolScore > PlayerPrefs.GetInt("MorolHighScore", 0))
        {
            PlayerPrefs.SetInt("MorolHighScore", morolScore);
            MorolCollectableText.text = PlayerPrefs.GetInt("MorolHighScore").ToString();
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
        PattyText.text = "" + pattScore;

        if(Movement.mInstance.isTaken == true)
        {
            pattScore = pattScore + 1;
            
            PattyText.text = "" + pattScore;
            PattyCollectableText.text = PattyText.text;
        }
    }
    public void addLettuceCount()
    {
        MorolText.text = "" + morolScore;
        if (Movement.mInstance.isTakenMorol == true)
        {
            morolScore += 1;
            MorolText.text = "" + morolScore;
            MorolCollectableText.text = MorolText.text;
        }
    }
    public void addOnionCount()
    {
        OnionText.text = "" + onionScore;
        if(Movement.mInstance.isTakeOnion == true)
        {
            onionScore += 1;
            OnionText.text = "" + onionScore;
            OnionCollectableText.text = OnionText.text;
        }
    }
    public void addTomatoCount()
    {
        TomatoText.text = "" + tomatoScore;
        if(Movement.mInstance.isTakenTomato == true)
        {
            tomatoScore += 1;
            TomatoText.text = "" + tomatoScore;
            TomatoCollectableText.text = tomatText.text;
        }
    }
}
