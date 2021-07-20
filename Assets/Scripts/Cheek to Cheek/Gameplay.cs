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
    //private float timeRemaining;
    private float timePassed = 0f;
    private bool firstScenario = true;
    // Start is called before the first frame update
    void Awake()
    {
        richmondLips = FindObjectOfType<RichmondLips>();
        spotlight = FindObjectOfType<Spotlight>();
        sceneSwitch = FindObjectOfType<SceneSwitch>();
        threeSecondsLeft = gameObject.AddComponent<ThreeSecondsLeft>();
        animationController = FindObjectOfType<AnimationController>();
        countdowns = FindObjectsOfType<Countdown>().OrderBy(m => m.transform.position.x).ToArray();

        measureMS = threeSecondsLeft.ReturnSingleMeasure();
        Debug.Log(measureMS);
        //timeRemaining = sceneSwitch.ReturnTimeToSwitch();

        kissHit = new KissHit();
        kissHit.Action.Select.performed += x => GameAction();

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

    void Update()
    {
        spotlight.RotateSpotlight();

        //timeRemaining -= Time.deltaTime;
        timePassed += Time.deltaTime;

        if (firstScenario == true)
        {
            if (timePassed > measureMS * 3)
            {
                firstScenario = false;
                if(animationController.ReturnKissTriggered() == false)
                {
                    richmondLips.stopAnimation();
                    animationController.KissLoseAnimation();
                }
            }
        } else
        {
            animationController.CoverSwitch();
            if (timePassed > measureMS * 5)
            {
                countdowns[0].StartCountdown();
            }
        }
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
                Debug.Log("Lose");
            }
        }
    }
}
