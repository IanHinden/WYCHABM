using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoController : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] RawImage videoImage;

    private void Start()
    {
        videoImage.enabled = false;

        //videoPlayer.prepareCompleted += OnPrepareCompleted;
        if(videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
        }
    }

    public void PlayVideo()
    {
        StartCoroutine(PrepareAndPlayVideo());
    }

    private IEnumerator PrepareAndPlayVideo()
    {
        videoPlayer.frame = 0;
        videoPlayer.time = 0;
        videoImage.enabled = true;

        videoPlayer.Prepare();

        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        videoImage.texture = videoPlayer.targetTexture;
        videoImage.enabled = true;

        videoPlayer.Play();
    }

    public void StopVideo()
    {
        videoPlayer.Stop();
    }

    public void DisableVideo()
    {
        videoImage.enabled = false;
    }

    public void PlayVideoCont()
    {
        videoPlayer.Play();
    }
}
