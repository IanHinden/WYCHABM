using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Gameplay : MonoBehaviour
{
    private RichmondLips richmondLips;
    private Spotlight spotlight;
    private KissHit kissHit;
    private ThreeSecondsLeft threeSecondsLeft;
    private AnimationController animationController;

    private SceneSwitch sceneSwitch;
    private Countdown[] countdowns;

    private float measureMS;

    private float timePassed = 0f;
    private bool firstScenario = true;

    void Awake()
    {
        richmondLips = FindObjectOfType<RichmondLips>();
        spotlight = FindObjectOfType<Spotlight>();
        sceneSwitch = FindObjectOfType<SceneSwitch>();
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
        animationController = FindObjectOfType<AnimationController>();
        countdowns = FindObjectsOfType<Countdown>().OrderBy(m => m.transform.position.x).ToArray();

        measureMS = threeSecondsLeft.ReturnSingleMeasure();

        kissHit = new KissHit();
        kissHit.Action.Select.performed += x => GameAction();
        StartCoroutine(GameSwitcher());

        countdowns[1].StartCountdown();
    }


    private void OnEnable()
    {
        kissHit.Enable();
    }

    private void OnDisable()
    {
        kissHit.Disable();
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
        countdowns[0].StartCountdown();
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
            } else
            {
                animationController.HitLoseAnimation();
            }
        }
    }
}
