using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject[] Background;

    int index;
    void Start()
    {
        index = 0;
    }
    void Update()
    {
        if (index == 0)
        {
            Background[0].gameObject.SetActive(true);
            Background[1].gameObject.SetActive(false);
        }
        if (index == 1)
        {
            Background[0].gameObject.SetActive(false);
            Background[1].gameObject.SetActive(true);
        }
    }
    public void Next()
    {
        index += 1;

        if(index > Background.Length - 1)
        {
            index = 0;
        }
    }
    public void Previous()
    {
        index -= 1;

        if (index < 0)
        {
            index = Background.Length - 1;
        }
    }
}
