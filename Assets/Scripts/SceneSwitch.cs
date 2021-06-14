using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] float TimeToSwitch;
    [SerializeField] bool gameScene;
    [SerializeField] bool lastScene;

    public AudioClip newTrack;

    private MusicPlayer theMP;

    ThreeSecondsLeft threeSecondsLeft;

    private void Awake()
    {
        theMP = FindObjectOfType<MusicPlayer>();
        if (gameScene)
        {
            threeSecondsLeft = gameObject.AddComponent<ThreeSecondsLeft>();
        }
        StartCoroutine(WaitAndSwitch());
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
        float timeToEnd;

        if (gameScene)
        {
            timeToEnd = threeSecondsLeft.ReturnTimeToEnd();
            timeToSwitchCopy = TimeToSwitch - timeToEnd;

            while (timeToSwitchCopy > 0)
            {
                timeToSwitchCopy -= Time.deltaTime;
                yield return null;
            }

            threeSecondsLeft.StartCountdown();
            while (timeToEnd > 0)
            {
                timeToEnd -= Time.deltaTime;
                yield return null;
            }

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
        if (lastScene == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else
        {
            Application.Quit();
        }
    }

    public float ReturnTimeToSwitch()
    {
        return TimeToSwitch;
    }
}