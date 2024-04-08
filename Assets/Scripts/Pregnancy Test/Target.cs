using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] ScoreHandler scorehandler;
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] UIHandler uihandler;
    [SerializeField] PregnancyAnimationController pregnancyTestAnimationController;
    [SerializeField] PregnancyTestGameplay pregnancyTestGameplay;

    [SerializeField] GameObject strawberry;
    [SerializeField] Streamer streamer;

    float pregnancyScore = 0;
    bool full = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ScorePlus();
    }

    void ScorePlus()
    {
        pregnancyScore++;
        
        if(pregnancyScore == 7)
        {
            pregnancyTestAnimationController.SetPixel1();
        }

        if (pregnancyScore == 14)
        {
            pregnancyTestAnimationController.SetPixel2();
        }

        if (pregnancyScore == 21)
        {
            pregnancyTestAnimationController.SetPixel3();
        }

        if (pregnancyScore == 30 && full == false)
        {
            pregnancyTestAnimationController.SetPixel4();
            pregnancyTestAnimationController.StopPregnancyTest();
            full = true;
            scorehandler.IncrementScore();
            uihandler.WinDisplay();
        }
    }

    public IEnumerator WinOrLose()
    {
        streamer.StartStream();
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(7));

        pregnancyTestGameplay.OnDisable();
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        streamer.CancelInvoke();
        if (pregnancyScore < 50 && full == false)
        {
            full = true;
            uihandler.LoseDisplay();
        }
    }

    public void Reset()
    {
        full = false;
        pregnancyScore = 0;
        pregnancyTestAnimationController.Reset();
        streamer.CancelInvoke();
        streamer.RemoveAllDroplets();
        strawberry.transform.rotation = Quaternion.identity;
    }
}
