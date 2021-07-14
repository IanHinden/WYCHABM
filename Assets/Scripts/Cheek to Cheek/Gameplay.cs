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
        //Debug.Log(richmondLips.transform.position.y);
        spotlight.RotateSpotlight();

        timeRemaining -= Time.deltaTime;
    }

    private void GameAction()
    {
        if (timeRemaining > 5)
        {
            if(richmondLips.transform.position.y > 2.5 && richmondLips.transform.position.y < 3.2)
            {
                Debug.Log("Win");
            } else
            {
                Debug.Log("Lose");
            }
        } else
        {
            Debug.Log("Hit");
        }
    }
}
