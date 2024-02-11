using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer video;

    public VideoClip staticClip;
    public VideoClip dialogueClip;

    private void Start()
    {
        if(video == null)
        {
            video = GetComponentInChildren<VideoPlayer>();
        }

        PlayStatic();
    }

    public void PlayVideo()
    {
        //video.playbackSpeed = 1;
        video.Play();
    }

    public void PauseVideo()
    {
        //video.playbackSpeed = 0;
        video.Pause();
    }

    public void RestartVideo()
    {
        video.Stop();
        video.Play();
    }

    public void PlayStatic()
    {
        video.clip = staticClip;
        RestartVideo();
    }

    public void PlayDialogue()
    {
        video.clip = dialogueClip;
        RestartVideo();
    }

    public void ChangeVideo(VideoClip clip)
    {
        video.clip = clip;
    }
}
