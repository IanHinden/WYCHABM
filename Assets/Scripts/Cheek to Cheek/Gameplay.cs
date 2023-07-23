using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Gameplay : MonoBehaviour
{
    [Header("Essential Functions")]
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] ScoreHandler scorehandler;

    [Header("Level Objects")]
    [SerializeField] private RichmondLips richmondLips;
    [SerializeField] private Spotlight spotlight;
    [SerializeField] private GameControls gamecontrols;
    [SerializeField] private AnimationController animationController;

    private float measureMS;

    private bool firstScenario = true;

    void Awake()
    {
        measureMS = timefunctions.ReturnSingleMeasure();

        gamecontrols = new GameControls();
        gamecontrols.Move.Select.performed += x => GameAction();
        StartCoroutine(GameSwitcher());
    }


    private void OnEnable()
    {
        gamecontrols.Enable();
    }

    private void OnDisable()
    {
        gamecontrols.Disable();
    }

    private IEnumerator GameSwitcher()
    {
        yield return new WaitForSeconds(measureMS * 3);
        firstScenario = false;
        if (animationController.ReturnKissTriggered() == false)
        {
            richmondLips.stopAnimation();
            animationController.KissLoseAnimation();
        }
        animationController.CoverSwitch();
        yield return new WaitForSeconds(measureMS);
        //countdowns[0].StartCountdown();
        yield return new WaitForSeconds(measureMS * 3);
        if (animationController.ReturnHitTriggered() == false)
        {
            animationController.HitLoseAnimation();
        }
    }

    void Update()
    {
        spotlight.RotateSpotlight();
    }

    private void GameAction()
    {
        if (firstScenario == true)
        {
            richmondLips.stopAnimation();
            if(richmondLips.transform.position.y > 2.5 && richmondLips.transform.position.y < 3.2)
            {
                animationController.KissWinAnimation();
                scorehandler.IncrementScore();
            } else
            {
                animationController.KissLoseAnimation();
            }
        } else
        {
            spotlight.StopRotating();
            if(spotlight.transform.position.x > 2.9 && spotlight.transform.position.x < 3.7)
            {
                animationController.HitWinAnimation();
                scorehandler.IncrementScore();
            } else
            {
                animationController.HitLoseAnimation();
            }
        }
    }
}
