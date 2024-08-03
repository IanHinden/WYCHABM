using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoController : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] RawImage videoImage;

    private RenderTexture rt;

    public void PlayVideo()
    {
        videoPlayer.targetTexture.Release();

        rt = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
        rt.Create();

        videoPlayer.targetTexture = rt;
        videoImage.enabled = true;
        videoPlayer.Play();
    }
}
