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
    private float timeRemaining;
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
        timeRemaining = sceneSwitch.ReturnTimeToSwitch();

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

        timeRemaining -= Time.deltaTime;
    }

    private void GameAction()
    {
        if (timeRemaining > 5)
        {
            richmondLips.stopAnimation();
            if(richmondLips.transform.position.y > 2.5 && richmondLips.transform.position.y < 3.2)
            {
                animationController.KissWinAnimation();
            } else
            {
                Debug.Log("Lose");
            }
        } else
        {
            spotlight.StopRotating();
            if(spotlight.transform.position.x > 2.9 && spotlight.transform.position.x < 3.7)
            {
                Debug.Log("Win");
            } else
            {
                Debug.Log("Lose");
            }
        }
    }
}
