using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] GameObject scoreCard;

    private Animator scoreCardAnim;

    private TextMeshProUGUI scoreCardText;

    private float score = 0;
    void Awake()
    {
        scoreCardAnim = scoreCard.GetComponent<Animator>();
        scoreCardText = scoreCard.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }
    public void DisplayScoreCard()
    {
        score++;
        scoreCardText.text = score.ToString();
        scoreCardAnim.SetTrigger("Enter");
        StartCoroutine(HideScoreCard());
    }

    IEnumerator HideScoreCard()
    {
        yield return new WaitForSeconds(2);
        scoreCardAnim.SetTrigger("Exit");
    }
}
