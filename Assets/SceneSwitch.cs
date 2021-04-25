using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public AudioClip newTrack;

    private MusicPlayer theMP;

    private void Start()
    {
        theMP = FindObjectOfType<MusicPlayer>();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        theMP.ChangeBGM(newTrack);
    }
}