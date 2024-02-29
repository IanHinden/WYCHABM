using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobInterviewAnimationController : MonoBehaviour
{
    [SerializeField] GameObject QualifiedBubble;
    [SerializeField] GameObject CEOBubble;
    [SerializeField] GameObject DegreeBubble;

    private Animator qualifiedBubbledAnim;
    private Animator ceoBubbleAnim;
    private Animator degreeBubbleAnim;
    void Awake()
    {
        qualifiedBubbledAnim = QualifiedBubble.GetComponent<Animator>();
        ceoBubbleAnim = CEOBubble.GetComponent<Animator>();
        degreeBubbleAnim = DegreeBubble.GetComponent<Animator>();
    }

    public void SetQualifiedBubble()
    {
        if (qualifiedBubbledAnim != null)
        {
            qualifiedBubbledAnim.SetBool("Selected", true);
            ceoBubbleAnim.SetBool("Selected", false);
            degreeBubbleAnim.SetBool("Selected", false);
        }

    }

    public void SetCEOBubble()
    {
        if (qualifiedBubbledAnim != null)
        {
            qualifiedBubbledAnim.SetBool("Selected", false);
            ceoBubbleAnim.SetBool("Selected", true);
            degreeBubbleAnim.SetBool("Selected", false);
        }
    }

    public void SetDegreeBubble()
    {
        if (qualifiedBubbledAnim != null)
        {
            qualifiedBubbledAnim.SetBool("Selected", false);
            ceoBubbleAnim.SetBool("Selected", false);
            degreeBubbleAnim.SetBool("Selected", true);
        }
    }

    public void Reset()
    {
        if (qualifiedBubbledAnim != null)
        {
            SetQualifiedBubble();
        }
    }
}
