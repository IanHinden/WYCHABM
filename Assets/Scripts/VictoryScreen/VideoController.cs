using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoController : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] RawImage videoImage;
    public Texture2D blankTexture;

    private void Start()
    {
        videoImage.texture = blankTexture;
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
        videoImage.texture = blankTexture;
        //videoImage.enabled = false;

        if (videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
        }

        videoPlayer.Prepare();

        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        videoImage.texture = videoPlayer.targetTexture;
        videoImage.enabled = true;

        videoPlayer.Play();
    }
}
