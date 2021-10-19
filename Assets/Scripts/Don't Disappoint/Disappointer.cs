using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappointer : MonoBehaviour
{
    SuccessOrFail successOrFail;
    ThreeSecondsLeft threeSecondsLeft;
    SceneSwitch sceneSwitch;

    void Awake()
    {
        successOrFail = gameObject.AddComponent<SuccessOrFail>();
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
        sceneSwitch = FindObjectOfType<SceneSwitch>();
        StartCoroutine(WinOrLose());
    }

    IEnumerator WinOrLose()
    {
        float deadline = (2 * threeSecondsLeft.ReturnTimeToEnd()) - threeSecondsLeft.ReturnSingleMeasure();
        yield return new WaitForSeconds(deadline);
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        successOrFail.LoseDisplay();
    }
}
