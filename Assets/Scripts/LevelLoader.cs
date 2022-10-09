using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public LevelManager lvlManagerScript;

    public GameObject MainPage;
    public GameObject SettingsPage;
    public GameObject Shop;

    public void SettingsButton()
    {
        MainPage.SetActive(false);
        SettingsPage.SetActive(true);
    }
    public void BackToMainPage()
    {
        MainPage.SetActive(true);
        SettingsPage.SetActive(false);
        Shop.SetActive(false);
    }
    public void LoadNextLevel()
    {
        //LoadingCirle.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LaodSecondLevel()
    {
        //LoadingCirle.SetActive(true);
        //SceneManager.LoadScene("Level2");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void LaodThirdLevel()
    {
        //SceneManager.LoadScene("Level2");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    public void LaodForthLevel()
    {
        //SceneManager.LoadScene("Level2");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }
    public void LaodFifthLevel()
    {
        //SceneManager.LoadScene("Level2");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }
    public void ShopButton()
    {
        MainPage.SetActive(false);
        Shop.SetActive(true);
    }
    public void BackToMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void ResetButton()
    {
        LevelManager.lvlInstance.ResetButton();
    }
}
