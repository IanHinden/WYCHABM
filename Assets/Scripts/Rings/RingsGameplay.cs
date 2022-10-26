using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsGameplay : MonoBehaviour
{
    [SerializeField] ScoreHandler scorehandler;
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] UIHandler uihandler;

    Remove remove;
    float clicked = 0;

    Animator ringoneanim;
    Animator ringtwoanim;

    void Awake()
    {
        remove = new Remove();
        remove.Tap.Up.performed += x => RemoveRing();

        ringoneanim = FindObjectOfType<Ring>().GetComponent<Animator>();
        ringtwoanim = FindObjectOfType<RingTwo>().GetComponent<Animator>();

        StartCoroutine(WinOrLose());
    }

    private void OnEnable()
    {
        remove.Enable();
    }

    private void OnDisable()
    {
        remove.Disable();
    }

    private void RemoveRing()
    {
        clicked++;

        if(clicked == 1)
        {
            ringoneanim.SetTrigger("Start");
        }

        if (clicked == 2)
        {
            ringoneanim.SetTrigger("Second");
        }

        if (clicked == 3)
        {
            ringoneanim.SetTrigger("Third");
        }

        if (clicked == 5)
        {
            ringtwoanim.SetTrigger("Start");
        }

        if (clicked == 9)
        {
            ringtwoanim.SetTrigger("Second");
        }

        if (clicked == 14)
        {
            ringtwoanim.SetTrigger("Third");
        }

        if (clicked == 19)
        {
            ringtwoanim.SetTrigger("Fourth");
            scorehandler.IncrementScore();
            uihandler.WinDisplay();
        }
    }

    IEnumerator WinOrLose()
    {
        remove.Disable();
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(7));

        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        if (clicked < 19)
        {
            uihandler.LoseDisplay();
        }
    }
}
