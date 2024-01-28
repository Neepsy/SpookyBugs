using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    SettingsManager settings;

    private void Start()
    {
        settings = GameObject.FindGameObjectWithTag("Settings").GetComponent<SettingsManager>();
    }

    public void SetMusicVol(float f)
    {
        settings.SetMusicVolume(f);
    }

    public void SetNarrationVol(float f)
    {
        settings.SetNarrationVolume(f);
    }

    public void SetSFXVol(float f)
    {
        settings.SetSFXVolume(f);
    }

    public void SetSubtitles(bool b)
    {
        settings.SetSubtitlesActive(b);
    }

    public void close()
    {
       gameObject.SetActive(false);
    }
}
