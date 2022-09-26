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
    public LevelScript lvlScrp;
    [Header("UI: Score")]
    public int pattScore = 0;
    public int tomatoScore = 0;
    public int morolScore = 0;
    public int onionScore = 0;
    public int cheeseScore = 0;
    public int cucumberScore = 0;
    [Header("UI: CollectablesText")]
    public TMP_Text PattyCollectableText;
    public TMP_Text TomatoCollectableText;
    public TMP_Text MorolCollectableText;
    public TMP_Text OnionCollectableText;
    //public TMP_Text CheeseCollectableText;
    //public TMP_Text CucumberCollectableText;
    [Header("UI: Start Panel")]
    public TMP_Text PattyText;
    public TMP_Text TomatoText;
    public TMP_Text MorolText;
    public TMP_Text OnionText;
    //public TMP_Text CheeseText;
    //public TMP_Text CucumberText;
    [Header("UI: Win Panel")]
    public TMP_Text lettuceText;
    public TMP_Text oniText;
    public TMP_Text pattyText;
    public TMP_Text tomatText;
    //public TMP_Text cheText;
    //public TMP_Text cucText;
    [Header("UI: GameOver Panel")]
    public TMP_Text overLettuceText;
    public TMP_Text overOniText;
    public TMP_Text overPattyText;
    public TMP_Text overTomatText;
    //public TMP_Text overCheeseText;
    //public TMP_Text overCucumberText;
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

        lvlScrp = GetComponent<LevelScript>();

        GameIsPaused = false;

        PattyText.text = pattScore.ToString();
        MorolText.text = morolScore.ToString();
        OnionText.text = onionScore.ToString();
        TomatoText.text = tomatoScore.ToString();
        //CheeseText.text = cheeseScore.ToString();
        //CucumberText.text = cucumberScore.ToString();

        PattyCollectableText.text = pattScore.ToString();
        MorolCollectableText.text = morolScore.ToString();
        TomatoCollectableText.text = tomatoScore.ToString();
        OnionCollectableText.text = onionScore.ToString();
        //CheeseCollectableText.text = cheeseScore.ToString();
        //CucumberCollectableText.text = cucumberScore.ToString();

        Start_Panel.SetActive(true);
        GameOver_Panel.SetActive(false);
        player.SetActive(false);
        CollectableImg.SetActive(false);
        pauseButton.SetActive(false);
        resumeButton.SetActive(false);
    }
    void Update()
    {
        PattyText.text = pattScore.ToString();
        MorolText.text = morolScore.ToString();
        OnionText.text = onionScore.ToString();
        TomatoText.text = tomatoScore.ToString();
        //CheeseText.text = cheeseScore.ToString();
        //CucumberText.text = cucumberScore.ToString();

        PattyCollectableText.text = pattScore.ToString();
        MorolCollectableText.text = morolScore.ToString();
        TomatoCollectableText.text = tomatoScore.ToString();
        OnionCollectableText.text = onionScore.ToString();
        //CheeseCollectableText.text = cheeseScore.ToString();
        //CucumberCollectableText.text = cucumberScore.ToString();

        if (player.activeSelf && Movement.mInstance.isDone == true)
        {
            //Win panel text equal to start panel text
            lettuceText.text = morolScore.ToString();
            oniText.text = onionScore.ToString();
            tomatText.text = tomatoScore.ToString();
            pattyText.text = pattScore.ToString();
            //cheText.text = cheeseScore.ToString();
            //cucText.text = cucumberScore.ToString();
        }
        if (player.activeSelf && Movement.mInstance.isDead == true)
        {
            //Game over panel text equal to start panel
            overLettuceText.text = morolScore.ToString();
            overOniText.text = onionScore.ToString();
            overPattyText.text = pattScore.ToString();
            overTomatText.text = tomatoScore.ToString();
            //overCheeseText.text = cheeseScore.ToString();
            //overCucumberText.text = cucumberScore.ToString();
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
        lvlScrp.PassTheLevel();
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
            TomatoCollectableText.text = TomatoText.text;
        }
    }
    //public void addCheeseCount()
    //{
    //    CheeseText.text = "" + cheeseScore;
    //    if(Movement.mInstance.isTakenCheese == true)
    //    {
    //        cheeseScore += 1;
    //        CheeseText.text = "" + cheeseScore;
    //        CheeseCollectableText.text = CheeseText.text;
    //    }
    //}
    //public void addCucumberCount()
    //{
    //    CucumberText.text = "" + cucumberScore;
    //    if(Movement.mInstance.isTakenCucumber == true)
    //    {
    //        cucumberScore += 1;
    //        CucumberText.text = "" + cucumberScore;
    //        CucumberCollectableText.text = CucumberText.text;
    //    }
    //}
}