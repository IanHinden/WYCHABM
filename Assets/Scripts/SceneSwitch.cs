using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] float TimeToSwitch;
    [SerializeField] float measures;
    [SerializeField] bool gameScene;
    [SerializeField] bool measureSwitch;
    [SerializeField] bool lastScene;

    public AudioClip newTrack;

    private MusicPlayer theMP;

    ThreeSecondsLeft threeSecondsLeft;

    private void Awake()
    {
        theMP = FindObjectOfType<MusicPlayer>();
        if (gameScene || measureSwitch)
        {
            threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
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

        if (measureSwitch && !gameScene)
        {
            float singleMeasure = threeSecondsLeft.ReturnSingleMeasure();
            float measureSwitchTime = singleMeasure * measures;
            yield return new WaitForSeconds(measureSwitchTime);
            LoadNextScene();
        }
         else if (gameScene)
        {
            timeToEnd = threeSecondsLeft.ReturnTimeToEnd();
            if (measureSwitch)
            {
                float singleMeasure = threeSecondsLeft.ReturnSingleMeasure();
                timeToSwitchCopy = (singleMeasure * measures) - timeToEnd;
            }
            else
            {

                timeToSwitchCopy = TimeToSwitch - timeToEnd;
            }

            yield return new WaitForSeconds(timeToSwitchCopy);

            threeSecondsLeft.StartCountdown();
            yield return new WaitForSeconds(timeToEnd);

            LoadNextScene();
        } else
        {
            yield return new WaitForSeconds(timeToSwitchCopy);
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

    public float ReturnMeasures()
    {
        return measures;
    }
}