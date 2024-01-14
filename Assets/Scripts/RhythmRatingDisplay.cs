using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RhythmRatingDisplay : MonoBehaviour
{
    [SerializeField] GameObject rhythmRating;

    private TextMeshProUGUI rhythmRatingText;
    private Animator rhythmAnim;

    // Start is called before the first frame update
    void Awake()
    {
        rhythmRatingText = rhythmRating.GetComponent<TextMeshProUGUI>();
        rhythmAnim = rhythmRating.GetComponent<Animator>();
    }

    private void AnimateText()
    {
        rhythmAnim.Play("RhythmRatingDisplay", -1, 0f);
    }

    public void SetPerfect()
    {
        rhythmRatingText.text = "PERFECT!";
        rhythmAnim.Play("New State", -1, 0f);
        AnimateText();
    }

    public void SetGood()
    {
        rhythmRatingText.text = "NOT BAD";
        rhythmAnim.Play("New State", -1, 0f);
        AnimateText();
    }

    public void SetMiss()
    {
        rhythmRatingText.text = "MISS";
        rhythmAnim.Play("New State", -1, 0f);
        AnimateText();
    }

    public void ClearText()
    {
        rhythmRatingText.text = "";
    }
}
