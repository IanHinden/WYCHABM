using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTimerOD : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;

    private float measureMS;

    [SerializeField] GameObject back;
    [SerializeField] GameObject front;

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
        yield return new WaitForSeconds(measureMS * 2);
        flashingMove.SetTrigger("Flash");
    }

    public void Reset()
    {
        front.transform.position = new Vector3(0, 0, 0);
        front.transform.localScale = new Vector3(.4632f, .4632f, .4632f);
        flashingMove.ResetTrigger("Flash");
        frontSR.enabled = false;
        backSR.enabled = true;
    }
}
