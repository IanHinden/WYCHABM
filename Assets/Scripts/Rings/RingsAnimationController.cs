using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsAnimationController : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;

    [SerializeField] GameObject rightDog;
    [SerializeField] GameObject rightDogShocked;

    [SerializeField] GameObject goldRing;
    [SerializeField] GameObject silverRing;

    [SerializeField] GameObject SpaceUp;
    [SerializeField] GameObject SpaceDown;

    private SpriteRenderer rightDogSR;
    private SpriteRenderer rightDogShockedSR;

    private Animator silverRingAnim;

    private float halfMeasure;

    void Awake()
    {
        rightDogSR = rightDog.GetComponent<SpriteRenderer>();
        rightDogShockedSR = rightDogShocked.GetComponent<SpriteRenderer>();

        silverRingAnim = silverRing.GetComponent<Animator>();

        SetSpacebar(true);
        halfMeasure = 2 * timefunctions.ReturnQuarterNote();
        //StartCoroutine(SpaceAnimator());
    }

    private void SetSpacebar(bool up)
    {
        SpaceUp.SetActive(up);
        SpaceDown.SetActive(!up);
    }

    // Update is called once per frame
    public IEnumerator SpaceAnimator()
    {
        bool currState = false;
        while (true)
        {
            yield return new WaitForSeconds(halfMeasure);
            SetSpacebar(currState);
            currState = !currState;
        }
    }

    public void setPos1()
    {
        rightDogSR.enabled = false;
        rightDogShockedSR.enabled = true;
        silverRingAnim.SetTrigger("Pos1");
    }

    public void SetPos2()
    {
        silverRingAnim.SetTrigger("Pos2");
    }

    public void Reset()
    {
        rightDogSR.enabled = true;
        rightDogShockedSR.enabled = false;
    }
}
