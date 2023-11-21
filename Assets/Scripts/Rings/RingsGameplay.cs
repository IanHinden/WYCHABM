using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsGameplay : MonoBehaviour
{
    [SerializeField] ScoreHandler scorehandler;
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] UIHandler uihandler;

    [SerializeField] RingsAnimationController ringsAnimationController;

    GameControls gamecontrols;
    float clicked = 0;

    void Awake()
    {
        gamecontrols = new GameControls();
        gamecontrols.Move.Select.performed += x => RemoveRing();

        StartCoroutine(WinOrLose());
    }

    private void OnEnable()
    {
        gamecontrols.Enable();
    }

    private void OnDisable()
    {
        gamecontrols.Disable();
    }

    private void RemoveRing()
    {
        clicked++;

        if(clicked == 1)
        {
            //ringoneanim.SetTrigger("Start");
            ringsAnimationController.setPos1();
            StartCoroutine(ringsAnimationController.RightHotdogShake(.2f, .2f));
        }

        if (clicked == 2)
        {
            //ringoneanim.SetTrigger("Second");
            ringsAnimationController.SetPos2();
            StartCoroutine(ringsAnimationController.RightHotdogShake(.2f, .2f));
        }

        if (clicked == 3)
        {
            ringsAnimationController.SetPos3();
            StartCoroutine(ringsAnimationController.RightHotdogShake(.2f, .2f));
        }

        if (clicked == 5)
        {
            //ringtwoanim.SetTrigger("Start");
        }

        if (clicked == 9)
        {
            //ringtwoanim.SetTrigger("Second");
        }

        if (clicked == 14)
        {
            //ringtwoanim.SetTrigger("Third");
        }

        if (clicked == 19)
        {
            //ringtwoanim.SetTrigger("Fourth");
            scorehandler.IncrementScore();
            uihandler.WinDisplay();
        }
    }

    IEnumerator WinOrLose()
    {
        StartCoroutine(ringsAnimationController.SpaceAnimator());

        gamecontrols.Disable();
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

    public void Reset()
    {
        clicked = 0;
    }
}
