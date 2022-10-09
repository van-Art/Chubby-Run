using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButtons : MonoBehaviour
{

    [Header("Music effects")]
    public GameObject MusicOn;
    public GameObject MusicOff;

    [Header("Sound effects")]
    public GameObject SoundOn;
    public GameObject SoundOff;

    [Header("Booleans")]
    public bool muted = false;
    public bool soundMuted = false;

    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateMusicButtonIcon();
        //AudioListener.pause = muted;
        soundeffect();
    }
    void soundeffect()
    {
        if (!PlayerPrefs.HasKey("soundMuted"))
        {
            PlayerPrefs.SetInt("soundMuted", 0);
            LoadSound();
        }
        else
        {
            LoadSound();
        }
        UpdateSoundButtonIcon();
        //AudioListener.pause = muted;
    }
    public void OnMsuicButtonDown()
    {
        if(muted == false)
        {
            muted = true;
            SoundManager.instance.musicSrc.Stop();
        }
        else
        {
            muted = false;
            SoundManager.instance.musicSrc.Play();
        }
        Save();
        UpdateMusicButtonIcon();
    }

    void UpdateMusicButtonIcon()
    {
        if(muted == false)
        {
            MusicOn.SetActive(true);
            MusicOff.SetActive(false);
        }
        else
        {
            MusicOn.SetActive(false);
            MusicOff.SetActive(true);
        }
    }

    public void OnSoundButtonDown()
    {
        if (soundMuted == false)
        {
            soundMuted = true;
            SoundManager.instance.soundSrc.Stop();
            //AudioListener.pause = true;
        }
        else
        {
            soundMuted = false;
            SoundManager.instance.soundSrc.Play();
            //AudioListener.pause = false;
        }
        SaveSound();
        UpdateSoundButtonIcon();
    }
    void UpdateSoundButtonIcon()
    {
        if (soundMuted == false)
        {
            SoundOn.SetActive(true);
            SoundOff.SetActive(false);
        }
        else
        {
            SoundOn.SetActive(false);
            SoundOff.SetActive(true);
        }
    }

    void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

    void LoadSound()
    {
        soundMuted = PlayerPrefs.GetInt("soundMuted") == 1;
    }
    void SaveSound()
    {
        PlayerPrefs.SetInt("soundMuted", soundMuted ? 1 : 0);
    }
}
