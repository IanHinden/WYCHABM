using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] float TimeToSwitch;
    [SerializeField] bool gameScene;

    public AudioClip newTrack;

    private MusicPlayer theMP;

    ThreeSecondsLeft threeSecondsLeft;

    private void Awake()
    {
        theMP = FindObjectOfType<MusicPlayer>();
        StartCoroutine(WaitAndSwitch());
        if (gameScene)
        {
            threeSecondsLeft = gameObject.AddComponent<ThreeSecondsLeft>();
        }
    }
    public void PlayGame()
    {
        LoadNextScene();
        theMP.ChangeBGM(newTrack);
    }

    IEnumerator WaitAndSwitch()
    {
        if(TimeToSwitch == 0) { yield break; }

        float timeToSwitchCopy = TimeToSwitch;

        if (gameScene)
        {
            yield return new WaitForSeconds(TimeToSwitch - 4);
            threeSecondsLeft.StartCountdown();
            yield return new WaitForSeconds(4);
            LoadNextScene();
        } else
        {
            while(timeToSwitchCopy > 0)
            {
                timeToSwitchCopy -= Time.deltaTime;
                yield return null;
            }
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}