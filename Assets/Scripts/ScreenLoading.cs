using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ScreenLoading : MonoBehaviour
{
    public static ScreenLoading instance;

    [Header("Loading Scene")]
    int sceneID;
    [Header("Other objects")]
    public Image loadingImg;
    public TMP_Text progressText;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        StartCoroutine(AsyncLoad(sceneID));
    }
    public void StartLoading(int sceneID)
    {
        StartCoroutine(AsyncLoad(sceneID));
    }
    IEnumerator AsyncLoad(int sceneID)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
        while(!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            loadingImg.fillAmount = progress;
            progressText.text = string.Format("{0:0}", progress * 100);
            yield return null;
        }
    }
}
