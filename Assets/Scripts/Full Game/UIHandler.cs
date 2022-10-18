using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TimeFunctions timeFunctions;
    float singleMeasure;

    [SerializeField] Image winicon;
    [SerializeField] Image loseicon;
    Image greencircle;
    Image redx;

    [SerializeField] GameObject panel;
    [SerializeField] Slider timerSlider;
    [SerializeField] TextMeshProUGUI countdown;

    [SerializeField] TextMeshProUGUI textmesh;

    [SerializeField] GameObject scorecard;
    private Animator scoreCardAnim;
    private TextMeshProUGUI scoreCardText;

    private Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        singleMeasure = timeFunctions.ReturnSingleMeasure();

        greencircle = winicon.GetComponent<Image>();
        redx = loseicon.GetComponent<Image>();

        textmesh.text = "";
        anim = textmesh.GetComponent<Animator>();

        scoreCardAnim = scorecard.GetComponent<Animator>();
        scoreCardText = scorecard.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
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

    private void ResetSliderTimer()
    {
        timerSlider.maxValue = 4;
        timerSlider.value = 4;
    }

    public void Countdown(int totalMeasures)
    {
        StartCoroutine(TriggerCountdownAnimation(totalMeasures));
    }

    IEnumerator TriggerCountdownAnimation(int totalMeasures)
    {
        float totalTime = totalMeasures * singleMeasure;

        timerSlider.maxValue = totalMeasures - 1;
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

    private IEnumerator AnimateAndDestroy(string instructions)
    {
        anim.ResetTrigger("ResetAnim");
        anim.SetTrigger("StartAnim");
        yield return new WaitForSeconds(.6f);
        textmesh.text = instructions;
        yield return new WaitForSeconds(2f);
        textmesh.text = "";
        anim.SetTrigger("ResetAnim");
        anim.ResetTrigger("StartAnim");
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

    IEnumerator HideScoreCard()
    {
        yield return new WaitForSeconds(1.3f);
        scoreCardAnim.SetTrigger("Exit");
    }
}
