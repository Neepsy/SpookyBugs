using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class NarrationPlayer : MonoBehaviour
{
    public Narration narrations;
    public bool debugPlay;

    private bool isPlaying;

    private AudioSource audioSource;
    private GameObject subtitleObject;
    private TextMeshProUGUI subtitleText;

    private void Start()
    {
        // Find components
        audioSource = GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>();
        subtitleObject = GameObject.FindWithTag("Subtitle");
        subtitleText = subtitleObject.GetComponentInChildren<TextMeshProUGUI>();

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
        subtitleObject.SetActive(true);

        foreach (KeyValuePair<AudioClip, string> pair in n)
        {
            float length = (float)(pair.Key.length + 0.5);
            audioSource.PlayOneShot(pair.Key);
            subtitleText.text = pair.Value;
            yield return new WaitForSecondsRealtime(length);
        }

        subtitleText.text = "";
        subtitleObject.SetActive(false);

        isPlaying = false;
        yield return null;
    }
}
