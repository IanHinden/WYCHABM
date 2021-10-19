using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetermineEnding : MonoBehaviour
{
    ThreeSecondsLeft threeSecondsLeft;
    void Awake()
    {
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
        Debug.Log(threeSecondsLeft.ReturnScore());
        Debug.Log(threeSecondsLeft.ReturnBonusScore());
    }
}
