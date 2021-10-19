using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] bool noTimer;
    [SerializeField] float measures;
    [SerializeField] bool gameScene;
    [SerializeField] bool measureSwitch;
    [SerializeField] bool lastScene;

    float singleMeasure;

    public AudioClip newTrack;

    private MusicPlayer theMP;

    ThreeSecondsLeft threeSecondsLeft;

    private void Start()
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
        if(noTimer) { yield break; }
        float timeToSwitch;
        float timeToEnd;

        if (!gameScene)
        {
            singleMeasure = threeSecondsLeft.ReturnSingleMeasure();
            float measureSwitchTime = singleMeasure * measures;
            yield return new WaitForSeconds(measureSwitchTime);
            LoadNextScene();
        } else
        {
            timeToEnd = threeSecondsLeft.ReturnTimeToEnd();
            float singleMeasure = threeSecondsLeft.ReturnSingleMeasure();
            timeToSwitch = (singleMeasure * measures) - timeToEnd;

            yield return new WaitForSeconds(timeToSwitch);

            threeSecondsLeft.StartCountdown();
            yield return new WaitForSeconds(timeToEnd);

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

    public float ReturnMeasures()
    {
        return measures;
    }
}