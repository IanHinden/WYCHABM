using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAnimator : MonoBehaviour
{
    [SerializeField] GameObject leftLight;
    [SerializeField] GameObject middleLight;
    [SerializeField] GameObject rightLight;

    private SpriteRenderer leftLightSR;
    private SpriteRenderer middleLightSR;
    private SpriteRenderer rightLightSR;
    void Start()
    {
        leftLightSR = leftLight.GetComponent<SpriteRenderer>();
        middleLightSR = middleLight.GetComponent<SpriteRenderer>();
        rightLightSR = rightLight.GetComponent<SpriteRenderer>();
    }

    private void LeftLightOn()
    {
        leftLightSR.enabled = true;
    }

    private void LeftLightOff()
    {
        leftLightSR.enabled = false;
    }

    private void MiddleLightOn()
    {
        middleLightSR.enabled = true;
    }

    private void MiddleLightOff()
    {
        middleLightSR.enabled = false;
    }

    private void RightLightOn()
    {
        rightLightSR.enabled = true;
    }

    private void RighttLightOff()
    {
        rightLightSR.enabled = false;
    }
}
