using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveWinLoseLogic : MonoBehaviour
{
    [SerializeField] RoadRacer roadRacer;
    [SerializeField] UIHandler uiHandler;
    [SerializeField] ScoreHandler scoreHandler;
    [SerializeField] TimeFunctions timefunctions;
    void Awake()
    {
        StartCoroutine(WinOrLose());   
    }

    public IEnumerator WinOrLose()
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(3));

        if (roadRacer.GetScore() > 10)
        {
            Debug.Log("Win");
        } else
        {
            Debug.Log("Lose");
        }
    }
}
