using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappointer : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;
    [SerializeField] TimeFunctions timefunctions;

    void Awake()
    {
        StartCoroutine(WinOrLose());
    }

    IEnumerator WinOrLose()
    {
        yield return new WaitForSeconds(3);
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        //threeSecondsLeft.LoseDisplay();
        // Halloween 1987
        uihandler.LoseDisplay();
    }
}
