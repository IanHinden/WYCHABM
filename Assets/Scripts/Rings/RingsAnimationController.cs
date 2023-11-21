using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsAnimationController : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;

    [SerializeField] GameObject right;

    [SerializeField] GameObject leftDog;
    [SerializeField] GameObject leftDogShocked;
    [SerializeField] GameObject rightDog;
    [SerializeField] GameObject rightDogShocked;

    [SerializeField] GameObject diamondRing;
    [SerializeField] GameObject silverRing;

    [SerializeField] GameObject SpaceUp;
    [SerializeField] GameObject SpaceDown;

    private SpriteRenderer leftDogSR;
    private SpriteRenderer leftDogShockedSR;

    private SpriteRenderer rightDogSR;
    private SpriteRenderer rightDogShockedSR;

    private Animator silverRingAnim;
    private Animator diamongRingAnim;

    private float halfMeasure;

    void Awake()
    {
        leftDogSR = leftDog.GetComponent<SpriteRenderer>();
        leftDogShockedSR = leftDogShocked.GetComponent<SpriteRenderer>();
        rightDogSR = rightDog.GetComponent<SpriteRenderer>();
        rightDogShockedSR = rightDogShocked.GetComponent<SpriteRenderer>();

        silverRingAnim = silverRing.GetComponent<Animator>();
        diamongRingAnim = diamondRing.GetComponent<Animator>();
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

    public IEnumerator RightHotdogShake(float duration, float magnitude)
    {
        Vector3 originalPos = right.transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-.4f, .4f) * magnitude;
            float y = Random.Range(-.4f, .4f) * magnitude;

            right.transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }
    }

    public void setPos1()
    {
        leftDogSR.enabled = false;
        leftDogShockedSR.enabled = true;
        rightDogSR.enabled = false;
        rightDogShockedSR.enabled = true;
        silverRingAnim.SetTrigger("Pos1");
    }

    public void SetPos2()
    {
        silverRingAnim.SetTrigger("Pos2");
    }

    public void SetPos3()
    {
        silverRingAnim.SetTrigger("Pos3");
    }

    public void SetPos4()
    {
        diamongRingAnim.SetTrigger("Pos4");
    }

    public void SetPos5()
    {
        diamongRingAnim.SetTrigger("Pos5");
    }

    public void SetPos6()
    {
        diamongRingAnim.SetTrigger("Pos6");
    }

    public void Reset()
    {
        leftDogSR.enabled = true;
        leftDogShockedSR.enabled = false;
        rightDogSR.enabled = true;
        rightDogShockedSR.enabled = false;

        silverRing.transform.localPosition = new Vector3(-1.42f, -3.79f, 0);

        silverRingAnim.ResetTrigger("Pos1");
        silverRingAnim.ResetTrigger("Pos2");
        silverRingAnim.ResetTrigger("Pos3");

        diamongRingAnim.ResetTrigger("Pos4");
        diamongRingAnim.ResetTrigger("Pos5");
        diamongRingAnim.ResetTrigger("Pos6");
    }
}
