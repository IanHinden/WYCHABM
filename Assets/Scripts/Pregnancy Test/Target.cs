using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] ScoreHandler scorehandler;
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] UIHandler uihandler;

    float pregnancyScore = 0;
    bool full = false;

    void Awake()
    {
        StartCoroutine(WinOrLose());
    }

    // Update is called once per frame
    void Update()
    {
        if(pregnancyScore == 50 && full == false)
        {
            full = true;
            scorehandler.IncrementScore();
            uihandler.WinDisplay();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        pregnancyScore++;
    }

    IEnumerator WinOrLose()
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(7));

        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        if (pregnancyScore < 50 && full == false)
        {
            full = true;
            uihandler.LoseDisplay();
        }
    }
}
