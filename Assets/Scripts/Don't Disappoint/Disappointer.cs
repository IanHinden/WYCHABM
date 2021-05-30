using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappointer : MonoBehaviour
{
    SuccessOrFail successOrFail;
    ThreeSecondsLeft threeSecondsLeft;
    SceneSwitch sceneSwitch;
    // Start is called before the first frame update
    void Awake()
    {
        successOrFail = gameObject.AddComponent<SuccessOrFail>();
        threeSecondsLeft = gameObject.AddComponent<ThreeSecondsLeft>();
        sceneSwitch = FindObjectOfType<SceneSwitch>();
        StartCoroutine(WinOrLose());
    }

    IEnumerator WinOrLose()
    {
        float deadline = sceneSwitch.ReturnTimeToSwitch() - threeSecondsLeft.ReturnTimeToEnd() + (3 * threeSecondsLeft.ReturnSingleMeasure());
        while (deadline > 0)
        {
            deadline -= Time.deltaTime;
            yield return null;
        }
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        successOrFail.LoseDisplay();
    }
}
