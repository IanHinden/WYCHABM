using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsGameplay : MonoBehaviour
{
    [SerializeField] ScoreHandler scorehandler;
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] UIHandler uihandler;
    [SerializeField] pauseManager PM;

    [SerializeField] RingsAnimationController ringsAnimationController;
    [SerializeField] RingsSFX ringsSFX;

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
        if (PM.IsGamePaused() == false)
        {
            clicked++;

            if (clicked == 1)
            {
                //ringoneanim.SetTrigger("Start");
                ringsAnimationController.setPos1();
                StartCoroutine(ringsAnimationController.RightHotdogShake(.2f, .2f, 0));
                ringsSFX.PlayBalloon(1);
            }

            if (clicked == 2)
            {
                //ringoneanim.SetTrigger("Second");
                ringsAnimationController.SetPos2();
                StartCoroutine(ringsAnimationController.RightHotdogShake(.2f, .2f, 0));
                ringsSFX.PlayBalloon(1.3f);
            }

            if (clicked == 3)
            {
                ringsAnimationController.SetPos3();
                StartCoroutine(ringsAnimationController.RightHotdogShake(.2f, .2f, 0));
                ringsSFX.PlayBalloon(1.7f);
            }

            if (clicked == 5)
            {
                ringsAnimationController.SetPos4();
                StartCoroutine(ringsAnimationController.RightHotdogShake(.2f, .2f, 1));
                ringsSFX.PlayBalloon(2.2f);
            }

            if (clicked == 9)
            {
                ringsAnimationController.SetPos5();
                StartCoroutine(ringsAnimationController.RightHotdogShake(.2f, .2f, 1));
                ringsSFX.PlayBalloon(2.6f);
            }

            if (clicked == 14)
            {
                ringsAnimationController.SetPos6();
                StartCoroutine(ringsAnimationController.RightHotdogShake(.2f, .2f, 1));
                ringsSFX.PlayBalloon(3);
                scorehandler.IncrementScore(3);
                uihandler.WinDisplay();
            }
        }
    }

    public IEnumerator WinOrLose()
    {
        StartCoroutine(ringsAnimationController.SpaceAnimator());

        gamecontrols.Enable();
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(7));

        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        gamecontrols.Disable();
        if (clicked < 14)
        {
            uihandler.LoseDisplay();
        }
    }

    public void Reset()
    {
        clicked = 0;
        ringsAnimationController.Reset();
    }
}
