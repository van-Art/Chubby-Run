using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource musicSrc;
    public AudioSource soundSrc;
    public AudioClip[] clips;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);        }
        else
        {
            Destroy(gameObject);
        }
        musicSrc.clip = clips[Random.Range(0, clips.Length)];
        if(musicSrc.isPlaying == false)
        {
            musicSrc.clip = clips[Random.Range(0, clips.Length)];
        }
    }
    public void soundEffect()
    {
        soundSrc.Play();
    }
}
