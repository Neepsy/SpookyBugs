using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer video;

    public void PlayVideo()
    {
        video.playbackSpeed = 1;
    }

    public void PauseVideo()
    {
        video.playbackSpeed = 0;
    }

    public void RestartVideo()
    {
        video.Stop();
        video.Play();
    }

    public void ChangeVideo(VideoClip clip)
    {
        video.clip = clip;
    }
}
