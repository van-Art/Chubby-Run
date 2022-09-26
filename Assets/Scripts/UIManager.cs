using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject MusicOn;
    public GameObject MusicOff;
    public GameObject SoundOn;
    public GameObject SoundOff;

    void Start()
    {
        MusicOn.SetActive(true);
        SoundOn.SetActive(true);
    }
    public void musicOn()
    {
        MusicOn.SetActive(true);
        MusicOff.SetActive(false);
        //music audio on
    }
    public void musicOff()
    {
        MusicOn.SetActive(false);
        MusicOff.SetActive(true);
        //music audio off
    }
    public void soundOn()
    {
        SoundOn.SetActive(true);
        SoundOff.SetActive(false);
        //sound audio on
    }
    public void soundOff()
    {
        SoundOn.SetActive(false);
        SoundOff.SetActive(true);
        //sound off
    }
}
