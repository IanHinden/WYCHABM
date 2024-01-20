using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TimeFunctions timeFunctions;
    float singleMeasure;

    [Header("Win/Lose UI")]
    [SerializeField] Image winicon;
    [SerializeField] Image loseicon;
    [SerializeField] RhythmRatingDisplay rhythmRatingDisplay;
    Image greencircle;
    Image redx;

    [Header("Time Remaining UI")]
    [SerializeField] GameObject panel;
    [SerializeField] Slider timerSlider;
    [SerializeField] TextMeshProUGUI countdown;

    [SerializeField] TextMeshProUGUI textmesh;
    [SerializeField] TextMeshProUGUI kissHitText;

    [Header("Score UI")]
    [SerializeField] GameObject scorecard;
    private Animator scoreCardAnim;
    private TextMeshProUGUI scoreCardText;

    [SerializeField] GameObject frame;

    [SerializeField] MaskTransition mask;

    [Header("Start/Pause UI")]
    [SerializeField] GameObject startButtonContainer;
    [SerializeField] GameObject pauseButton;

    [SerializeField] GameObject instructionsMenuPanel;

    [Header("Score Screen")]
    [SerializeField] TextMeshProUGUI standardScore;
    [SerializeField] TextMeshProUGUI bonusScore;

    private Animator anim;
    private Animator kissHitAnim;

    // Start is called before the first frame update
    void Awake()
    {
        singleMeasure = timeFunctions.ReturnSingleMeasure();

        greencircle = winicon.GetComponent<Image>();
        redx = loseicon.GetComponent<Image>();

        textmesh.text = "";
        anim = textmesh.GetComponent<Animator>();
        kissHitAnim = kissHitText.GetComponent<Animator>();

        scoreCardAnim = scorecard.GetComponent<Animator>();
        scoreCardText = scorecard.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    public void HidePauseButton()
    {
        pauseButton.SetActive(false);
    }

    public void ShowPauseButton()
    {
        pauseButton.SetActive(true);
    }

    public void WinDisplay()
    {
        greencircle.enabled = true;
    }

    public void LoseDisplay()
    {
        redx.enabled = true;
    }

    public void ClearWinLoss()
    {
        greencircle.enabled = false;
        redx.enabled = false;
    }

    public void ClearInstructions()
    {
        textmesh.text = "";
    }

    private void ResetSliderTimer()
    {
        timerSlider.maxValue = 4;
        timerSlider.value = 4;
    }

    public void Countdown(int totalMeasures)
    {
        StartCoroutine(TriggerCountdownAnimation(totalMeasures));
    }

    public void CountdownCheek()
    {
        StartCoroutine(TriggerCountdownCheekAnimation());
    }

    IEnumerator TriggerCountdownAnimation(int totalMeasures)
    {
        float totalTime = totalMeasures * singleMeasure;

        timerSlider.maxValue = totalMeasures > 3 ? totalMeasures - 1 : totalMeasures;
        timerSlider.value = totalMeasures;
        
        countdown.text = " ";

        while(totalTime > 3)
        {
            yield return new WaitForSeconds(singleMeasure);
            totalTime -= singleMeasure;
            timerSlider.value--;
        }

        countdown.text = "3";
        timerSlider.value = 3;

        yield return new WaitForSeconds(singleMeasure);
        countdown.text = "2";
        timerSlider.value = 2;

        yield return new WaitForSeconds(singleMeasure);
        countdown.text = "1";
        timerSlider.value = 1;

        yield return new WaitForSeconds(singleMeasure);
        countdown.text = "0";
        timerSlider.value = 0;
    }

    IEnumerator TriggerCountdownCheekAnimation()
    {
        float totalTime = 3 * singleMeasure;

        timerSlider.maxValue = 3;
        timerSlider.value = 3;

        countdown.text = " ";

        while (totalTime > 3)
        {
            yield return new WaitForSeconds(singleMeasure);
            totalTime -= singleMeasure;
            timerSlider.value--;
        }

        countdown.text = "3";
        timerSlider.value = 3;

        yield return new WaitForSeconds(singleMeasure);
        countdown.text = "2";
        timerSlider.value = 2;

        yield return new WaitForSeconds(singleMeasure);
        countdown.text = "1";
        timerSlider.value = 1;

        yield return new WaitForSeconds(singleMeasure);
        countdown.text = "0";
        timerSlider.value = 0;

        yield return new WaitForSeconds(singleMeasure);

        countdown.text = " ";

        while (totalTime > 3)
        {
            yield return new WaitForSeconds(singleMeasure);
            totalTime -= singleMeasure;
            timerSlider.value--;
        }

        countdown.text = "3";
        timerSlider.value = 3;

        yield return new WaitForSeconds(singleMeasure);
        countdown.text = "2";
        timerSlider.value = 2;

        yield return new WaitForSeconds(singleMeasure);
        countdown.text = "1";
        timerSlider.value = 1;

        yield return new WaitForSeconds(singleMeasure);
        countdown.text = "0";
        timerSlider.value = 0;
    }

    public void setFrame(bool show)
    {
        frame.SetActive(show);
    }

    public void showSlider()
    {
        panel.SetActive(true);
    }

    public void hideSlider()
    {
        panel.SetActive(false);
    }

    public void InstructionText(string instructions)
    {
        StartCoroutine(AnimateAndDestroy(instructions));
    }

    public void InstructionTextKissHit(string instructions)
    {
        StartCoroutine(AnimateAndDestroyKissHit(instructions));
    }

    private IEnumerator AnimateAndDestroy(string instructions)
    {
        yield return new WaitForSeconds(.6f);
        textmesh.text = instructions;
        anim.SetBool("Animate", true);
        yield return new WaitForSeconds(2f);
        textmesh.text = "";
        anim.SetBool("Animate", false);
    }

    private IEnumerator AnimateAndDestroyKissHit(string instructions)
    {
        yield return new WaitForSeconds(.3f);
        kissHitText.text = instructions;
        kissHitAnim.SetBool("Animate", true);
        yield return new WaitForSeconds(1.5f);
        kissHitText.text = "";
        kissHitAnim.SetBool("Animate", false);
    }

    public IEnumerator DisplayScoreCard(int score)
    {
        int prevscore = score - 1;
        scoreCardText.text = prevscore.ToString();
        scoreCardAnim.SetTrigger("Enter");
        yield return new WaitForSeconds(.8f);
        scoreCardText.text = score.ToString();
        StartCoroutine(HideScoreCard());
    }

    public IEnumerator DisplayScoreCardTwo(int score)
    {
        int prevscore = score - 2;
        int midscore = score - 1;
        scoreCardText.text = prevscore.ToString();
        scoreCardAnim.SetTrigger("Enter");
        yield return new WaitForSeconds(.8f);
        scoreCardText.text = midscore.ToString();
        yield return new WaitForSeconds(.4f);
        scoreCardText.text = score.ToString();
        StartCoroutine(HideScoreCard());
    }

    IEnumerator HideScoreCard()
    {
        yield return new WaitForSeconds(1.3f);
        scoreCardAnim.SetTrigger("Exit");
    }

    public void MaskOutro(Vector2 maskCoordinates)
    {
        StartCoroutine(mask.TransitionOutro(maskCoordinates));
    }

    public void MaskIntro(Vector2 maskCoordinates)
    {
        StartCoroutine(mask.TransitionIntro(maskCoordinates));
    }

    public void HideStartButton()
    {
        startButtonContainer.SetActive(false);
        instructionsMenuPanel.SetActive(false);
    }

    public void SetScoreScreenStandardScore(string score)
    {
        standardScore.text = score;
    }

    public void SetScoreScreenBonusScore(string score)
    {
        bonusScore.text = score;
    }

    private void ClearSetScoreScreenText()
    {
        standardScore.text = "";
        bonusScore.text = "";
    }

    public void ClearRhythmRating()
    {
        rhythmRatingDisplay.ClearText();
    }

    public void Reset()
    {
        ClearWinLoss();
        setFrame(false);
        hideSlider();
        ClearInstructions();
        ClearSetScoreScreenText();
        HidePauseButton();
        ClearRhythmRating();
    }
}
