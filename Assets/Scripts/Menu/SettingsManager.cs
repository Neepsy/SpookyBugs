using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    public float musicVolume { get; private set; }
    public float narrationVolume { get; private set; }
    public float sfxVolume { get; private set; }
    public bool subtitlesActive { get; private set; }



    public AudioMixer mixer;

    static SettingsManager INSTANCE;


    // Start is called before the first frame update
    void Start()
    {
        
        musicVolume = 1.0f;
        narrationVolume = 1.0f;
        sfxVolume = 1.0f;
        subtitlesActive = true;

        if(INSTANCE == null)
        {
            INSTANCE = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    public void SetMusicVolume(float vol)
    {
        Mathf.Clamp(vol, 0, 1f);
        musicVolume = vol;
        mixer.SetFloat("MusicVol", (vol - 1) * 80);
    }

    public void SetNarrationVolume(float vol)
    {
        Mathf.Clamp(vol, 0, 1f);
        narrationVolume = vol;
        mixer.SetFloat("NarrationVol", (vol - 1) * 80);
    }

    public void SetSFXVolume(float vol)
    {
        Mathf.Clamp(vol, 0, 1f);
        narrationVolume = vol;
        mixer.SetFloat("SFXVol", (vol - 1) * 80);
    }

    public void SetSubtitlesActive(bool active)
    {
        subtitlesActive = active;
    }
}
