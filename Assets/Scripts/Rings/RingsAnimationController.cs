using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsAnimationController : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;

    [SerializeField] GameObject right;
    [SerializeField] GameObject left;

    [SerializeField] GameObject leftDog;
    [SerializeField] GameObject leftDogShocked;
    [SerializeField] GameObject leftDogDifficult;
    [SerializeField] GameObject rightDog;
    [SerializeField] GameObject rightDogShocked;

    [SerializeField] GameObject leftShakes;
    [SerializeField] GameObject rightShakes;

    [SerializeField] GameObject shockedEmotion;

    [SerializeField] GameObject diamondRing;
    [SerializeField] GameObject silverRing;

    [SerializeField] GameObject SpaceUp;
    [SerializeField] GameObject SpaceDown;

    private SpriteRenderer leftDogSR;
    private SpriteRenderer leftDogShockedSR;
    private SpriteRenderer leftDogDifficultSR;

    private SpriteRenderer rightDogSR;
    private SpriteRenderer rightDogShockedSR;

    private SpriteRenderer diamondRingFrontSR;
    private SpriteRenderer diamonRingBackSR;

    private SpriteRenderer silverRingFrontSR;
    private SpriteRenderer silverRingBackSR;

    private Animator silverRingAnim;
    private Animator diamongRingAnim;

    private float halfMeasure;

    void Awake()
    {
        leftDogSR = leftDog.GetComponent<SpriteRenderer>();
        leftDogShockedSR = leftDogShocked.GetComponent<SpriteRenderer>();
        leftDogDifficultSR = leftDogDifficult.GetComponent<SpriteRenderer>();
        rightDogSR = rightDog.GetComponent<SpriteRenderer>();
        rightDogShockedSR = rightDogShocked.GetComponent<SpriteRenderer>();

        diamondRingFrontSR = diamondRing.transform.GetChild(0).GetComponent<SpriteRenderer>();
        diamonRingBackSR = diamondRing.transform.GetChild(1).GetComponent<SpriteRenderer>();

        silverRingFrontSR = silverRing.transform.GetChild(0).GetComponent<SpriteRenderer>();
        silverRingBackSR = silverRing.transform.GetChild(1).GetComponent<SpriteRenderer>();

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

    public IEnumerator RightHotdogShake(float duration, float magnitude, int dog)
    {
        GameObject theDog = dog == 0 ? right : left;
        GameObject theShakes = dog == 0 ? rightShakes : leftShakes;
        Vector3 originalPos = theDog.transform.localPosition;

        float elapsed = 0.0f;

        theShakes.SetActive(true);

        while (elapsed < duration)
        {
            float x = Random.Range(-.4f, .4f) * magnitude;
            float y = Random.Range(-.4f, .4f) * magnitude;

            theDog.transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        theShakes.SetActive(false);
    }

    public void setPos1()
    {
        StartCoroutine(shockedEmotionAppear());

        leftDogSR.enabled = false;
        leftDogShockedSR.enabled = true;
        rightDogSR.enabled = false;
        rightDogShockedSR.enabled = true;
        silverRingAnim.SetTrigger("Pos1");
    }

    private IEnumerator shockedEmotionAppear()
    {
        shockedEmotion.SetActive(true);
        yield return new WaitForSeconds(.2f);
        shockedEmotion.SetActive(false);
        yield return new WaitForSeconds(.2f);
        shockedEmotion.SetActive(true);
        yield return new WaitForSeconds(.2f);
        shockedEmotion.SetActive(false);
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
        leftDogShockedSR.enabled = false;
        leftDogDifficultSR.enabled = true;
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
        if (leftDogSR != null)
        {
            leftDogSR.enabled = true;
            leftDogShockedSR.enabled = false;
            leftDogDifficultSR.enabled = false;
            rightDogSR.enabled = true;
            rightDogShockedSR.enabled = false;

            diamondRingFrontSR.color = new Color(1, 1, 1, 1);
            diamonRingBackSR.color = new Color(1, 1, 1, 1);

            silverRingFrontSR.color = new Color(1, 1, 1, 1);
            silverRingBackSR.color = new Color(1, 1, 1, 1);

            diamondRing.transform.localPosition = new Vector3(-3.13f, -3.79f, 0);
            silverRing.transform.localPosition = new Vector3(-1.42f, -3.79f, 0);

            silverRingAnim.ResetTrigger("Pos1");
            silverRingAnim.ResetTrigger("Pos2");
            silverRingAnim.ResetTrigger("Pos3");

            diamongRingAnim.ResetTrigger("Pos4");
            diamongRingAnim.ResetTrigger("Pos5");
            diamongRingAnim.ResetTrigger("Pos6");
        }
    }
}
