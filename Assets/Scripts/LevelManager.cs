using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager lvlInstance;
    int levelsUnlocked;

    public Button[] levelButtons;

    void Start()
    {
        lvlInstance = this;

        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);

        for(int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].transform.GetChild(1).gameObject.SetActive(true);
        }

        for (int i = 0; i < levelsUnlocked; i++)
        {
            levelButtons[i].transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            levelsUnlocked = 1;
            PlayerPrefs.SetInt("levelsUnlocked", 1);
            Debug.Log("reset");
        }
    }
    public void ResetButton()
    {
        levelsUnlocked = 1;
        PlayerPrefs.SetInt("levelsUnlocked", 1);
        Debug.Log("reset");
    }
}
