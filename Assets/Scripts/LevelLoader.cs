using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator Transition;

    public float transitionTime = 1f;

    public GameObject MainPage;
    public GameObject SettingsPage;

    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //    LoadNextLevel();
    }
    public void SettingsButton()
    {
        MainPage.SetActive(false);
        SettingsPage.SetActive(true);
    }
    public void BackToMainPage()
    {
        MainPage.SetActive(true);
        SettingsPage.SetActive(false);
    }
    public void LoadNextLevel()
    {
        //StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void BackToMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        Transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
