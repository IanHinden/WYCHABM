using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTimerOD : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;

    private float measureMS;

    [SerializeField] GameObject back;
    [SerializeField] GameObject front;

    [SerializeField] GameObject emptyBubbles;
    [SerializeField] GameObject fullBubbles;

    private SpriteRenderer backSR;
    private SpriteRenderer frontSR;
    
    private Animator flashingMove;

    void Awake()
    {
        measureMS = timefunctions.ReturnSingleMeasure();

        backSR = back.GetComponent<SpriteRenderer>();
        frontSR = front.GetComponent<SpriteRenderer>();

        flashingMove = front.GetComponent<Animator>();
    }

    public IEnumerator SceneTiming()
    {
        yield return new WaitForSeconds(measureMS * 4f);
        frontSR.enabled = true;
        backSR.enabled = false;

        FullBubblesActivation(false);
        EmptyBubblesActivation(true);
        yield return new WaitForSeconds(measureMS * 2);
        flashingMove.SetTrigger("Flash");
    }

    private void FullBubblesActivation(bool activate)
    {
        foreach (Transform child in fullBubbles.transform)
        {
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = activate;
            }
        }
    }

    private void EmptyBubblesActivation(bool activate)
    {
        foreach (Transform child in emptyBubbles.transform)
        {
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = activate;
            }
        }
    }

    public void Reset()
    {
        front.transform.position = new Vector3(0, 0, 0);
        front.transform.localScale = new Vector3(.4632f, .4632f, .4632f);
        
        FullBubblesActivation(true);
        EmptyBubblesActivation(false);

        if (flashingMove != null)
        {
            flashingMove.ResetTrigger("Flash");
            frontSR.enabled = false;
            backSR.enabled = true;
        }
    }
}
