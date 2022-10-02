using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIGameManager : MonoBehaviour
{
    [Header("UI: Score")]
    public int pattScore = 0;
    public int tomatoScore = 0;
    public int morolScore = 0;
    public int onionScore = 0;
    public int cheeseScore = 0;
    public int cucumberScore = 0;
    [Header("UI: CollectablesText")]
    [SerializeField] private TMP_Text PattyCollectableText;
    [SerializeField] private TMP_Text TomatoCollectableText;
    [SerializeField] private TMP_Text MorolCollectableText;
    [SerializeField] private TMP_Text OnionCollectableText;
    [SerializeField] private TMP_Text CheeseCollectableText;
    [SerializeField] private TMP_Text CucumberCollectableText;
    [Header("UI: Start Panel")]
    [SerializeField] private TMP_Text PattyText;
    [SerializeField] private TMP_Text TomatoText;
    [SerializeField] private TMP_Text MorolText;
    [SerializeField] private TMP_Text OnionText;
    [SerializeField] private TMP_Text CheeseText;
    [SerializeField] private TMP_Text CucumberText;
    [Header("UI: Win Panel")]
    [SerializeField] private TMP_Text pattyText;
    [SerializeField] private TMP_Text tomatText;
    [SerializeField] private TMP_Text lettuceText;
    [SerializeField] private TMP_Text oniText;
    [SerializeField] private TMP_Text cheText;
    [SerializeField] private TMP_Text cucText;
    [Header("UI: GameOver Panel")]
    [SerializeField] private TMP_Text overPattyText;
    [SerializeField] private TMP_Text overTomatText;
    [SerializeField] private TMP_Text overLettuceText;
    [SerializeField] private TMP_Text overOniText;
    [SerializeField] private TMP_Text overCheeseText;
    [SerializeField] private TMP_Text overCucumberText;

    void Start()
    {
        PattyText.text = pattScore.ToString();
        MorolText.text = morolScore.ToString();
        OnionText.text = onionScore.ToString();
        TomatoText.text = tomatoScore.ToString();
        CheeseText.text = cheeseScore.ToString();
        CucumberText.text = cucumberScore.ToString();

        PattyCollectableText.text = pattScore.ToString();
        MorolCollectableText.text = morolScore.ToString();
        TomatoCollectableText.text = tomatoScore.ToString();
        OnionCollectableText.text = onionScore.ToString();
        CheeseCollectableText.text = cheeseScore.ToString();
        CucumberCollectableText.text = cucumberScore.ToString();

        overPattyText.text = pattScore.ToString();
        overLettuceText.text = morolScore.ToString();
        overTomatText.text = tomatoScore.ToString();
        overOniText.text = onionScore.ToString();
        overCheeseText.text = cheeseScore.ToString();
        overCucumberText.text = cucumberScore.ToString();
    }
    void Update()
    {
        PattyText.text = pattScore.ToString();
        MorolText.text = morolScore.ToString();
        OnionText.text = onionScore.ToString();
        TomatoText.text = tomatoScore.ToString();
        CheeseText.text = cheeseScore.ToString();
        CucumberText.text = cucumberScore.ToString();

        PattyCollectableText.text = pattScore.ToString();
        MorolCollectableText.text = morolScore.ToString();
        TomatoCollectableText.text = tomatoScore.ToString();
        OnionCollectableText.text = onionScore.ToString();
        CheeseCollectableText.text = cheeseScore.ToString();
        CucumberCollectableText.text = cucumberScore.ToString();

        overPattyText.text = pattScore.ToString();
        overLettuceText.text = morolScore.ToString();
        overTomatText.text = tomatoScore.ToString();
        overOniText.text = onionScore.ToString();
        overCheeseText.text = cheeseScore.ToString();
        overCucumberText.text = cucumberScore.ToString();
        //Invoke("Over", .1f);
    }
    public void WinPanelText()
    {
        lettuceText.text = morolScore.ToString();
        oniText.text = onionScore.ToString();
        tomatText.text = tomatoScore.ToString();
        pattyText.text = pattScore.ToString();
        cheText.text = cheeseScore.ToString();
        cucText.text = cucumberScore.ToString();
    }
    public void OverPanelText()
    {
        overLettuceText.text = morolScore.ToString();
        overOniText.text = onionScore.ToString();
        overPattyText.text = pattScore.ToString();
        overTomatText.text = tomatoScore.ToString();
        overCheeseText.text = cheeseScore.ToString();
        overCucumberText.text = cucumberScore.ToString();
    }
    //void Over()
    //{
    //    if (FindObjectOfType<Movement>().isDead == true)
    //    {
    //        OverPanelText();
    //    }
    //}
    public void addPattyCount()
    {
        PattyText.text = "" + pattScore;

        if (FindObjectOfType<Movement>().isTaken == true)
        {
            pattScore = pattScore + 1;

            PattyText.text = "" + pattScore;
            PattyCollectableText.text = PattyText.text;
            Debug.Log("pattScore: " + pattScore);
        }
    }
    public void addLettuceCount()
    {
        MorolText.text = "" + morolScore;
        if (FindObjectOfType<Movement>().isTakenMorol == true)
        {
            morolScore += 1;
            MorolText.text = "" + morolScore;
            MorolCollectableText.text = MorolText.text;
        }
    }
    public void addOnionCount()
    {
        OnionText.text = "" + onionScore;
        if (FindObjectOfType<Movement>().isTakeOnion == true)
        {
            onionScore += 1;
            OnionText.text = "" + onionScore;
            OnionCollectableText.text = OnionText.text;
        }
    }
    public void addTomatoCount()
    {
        TomatoText.text = "" + tomatoScore;
        if (FindObjectOfType<Movement>().isTakenTomato == true)
        {
            tomatoScore += 1;
            TomatoText.text = "" + tomatoScore;
            TomatoCollectableText.text = TomatoText.text;
        }
    }
    public void addCheeseCount()
    {
        CheeseText.text = "" + cheeseScore;
        if (Movement.mInstance.isTakenCheese == true)
        {
            cheeseScore += 1;
            CheeseText.text = "" + cheeseScore;
            CheeseCollectableText.text = CheeseText.text;
        }
    }
    //public void addCucumberCount()
    //{
    //    CucumberText.text = "" + cucumberScore;
    //    if (Movement.mInstance.isTakenCucumber == true)
    //    {
    //        cucumberScore += 1;
    //        CucumberText.text = "" + cucumberScore;
    //        CucumberCollectableText.text = CucumberText.text;
    //    }
    //}
}
