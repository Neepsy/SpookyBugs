using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class NarrationPlayer : MonoBehaviour
{
    public Narration narrations;
    public bool debugPlay;

    private bool isPlaying;

    private AudioSource audioSource;
    private GameObject subtitleObject;
    private TextMeshProUGUI subtitleText;
    private SettingsManager settings;

    public UnityEvent afterEvent;

    private void Start()
    {
        // Find components
        audioSource = GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>();
        subtitleObject = GameObject.FindWithTag("Subtitle");
        subtitleText = subtitleObject.GetComponentInChildren<TextMeshProUGUI>();

        try
        {
            settings = GameObject.FindWithTag("Settings").GetComponent<SettingsManager>();
        }
        catch(Exception e)
        {
            settings = new SettingsManager();
            settings.SetSubtitlesActive(true);
        }
        

        subtitleObject.SetActive(false);
    }

    private void Update()
    {
        if (debugPlay)
        {
            Play();
            debugPlay = false;
        }
    }

    //Play clips assigned to this GameObject
    public void Play()
    {
        Play(narrations);
    }

    //Play any narration ScriptableObject
    public void Play(Narration n)
    {
        if (isPlaying) return;

        if (n.clips.Length == n.subtitles.Length){

            // Assemble clips and subtitles into dictionary
            var dict = n.clips.Zip(n.subtitles, (c, s) => new {c, s})
                              .ToDictionary(item => item.c, item => item.s);

            StartCoroutine(PlayNarrations(dict));
        }
        else
        {
            Debug.LogError(n.name + ": clips and subtitles mismatched length!");
        }
    }


    IEnumerator PlayNarrations(Dictionary<AudioClip, string> n)
    {
        isPlaying = true;
        
        foreach (KeyValuePair<AudioClip, string> pair in n)
        {
            float length = (float)(pair.Key.length + 0.5);
            audioSource.PlayOneShot(pair.Key);
            SetSubtitle(pair.Value);
            yield return new WaitForSecondsRealtime(length);
        }

        SetSubtitle("");
        subtitleObject.SetActive(false);

        isPlaying = false;
        afterEvent.Invoke();
        yield return null;
    }

    private void SetSubtitle(string subtitle)
    {
        if (!settings.subtitlesActive) return;

        if (string.IsNullOrEmpty(subtitle))
        {
            subtitleObject.SetActive(false);
        }

        subtitleObject.SetActive(true);
        subtitleText.text = subtitle;
    }
}
