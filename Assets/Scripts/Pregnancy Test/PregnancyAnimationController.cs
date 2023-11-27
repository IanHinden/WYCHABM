using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PregnancyAnimationController : MonoBehaviour
{
    [SerializeField] GameObject pregnancyTest;

    Animator pregnancyTestAnim;

    [SerializeField] GameObject pixel1;
    [SerializeField] GameObject pixel2;
    [SerializeField] GameObject pixel3;
    [SerializeField] GameObject pixel4;

    private SpriteRenderer pixel1SR;
    private SpriteRenderer pixel2SR;
    private SpriteRenderer pixel3SR;
    private SpriteRenderer pixel4SR;

    private void Awake()
    {
        pregnancyTestAnim = pregnancyTest.GetComponent<Animator>();

        pixel1SR = pixel1.GetComponent<SpriteRenderer>();
        pixel2SR = pixel2.GetComponent<SpriteRenderer>();
        pixel3SR = pixel3.GetComponent<SpriteRenderer>();
        pixel4SR = pixel4.GetComponent<SpriteRenderer>();
    }

    public void SetPixel1()
    {
        pixel1SR.enabled = true;
    }
    public void SetPixel2()
    {
        pixel2SR.enabled = true;
    }

    public void SetPixel3()
    {
        pixel3SR.enabled = true;
    }

    public void SetPixel4()
    {
        pixel4SR.enabled = true;
    }

    public void StopPregnancyTest()
    {
        pregnancyTestAnim.StopPlayback();
    }

    public void Reset()
    {
        pixel1SR.enabled = false;
        pixel2SR.enabled = false;
        pixel3SR.enabled = false;
        pixel4SR.enabled = false;
    }
}
