using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    private RichmondLips richmondLips;
    private Spotlight spotlight;
    private KissHit kissHit;
    private ThreeSecondsLeft threeSecondsLeft;
    private SceneSwitch sceneSwitch;

    private float measureMS;
    private float timeRemaining;
    // Start is called before the first frame update
    void Awake()
    {
        richmondLips = FindObjectOfType<RichmondLips>();
        spotlight = FindObjectOfType<Spotlight>();
        sceneSwitch = FindObjectOfType<SceneSwitch>();
        threeSecondsLeft = gameObject.AddComponent<ThreeSecondsLeft>();
        measureMS = threeSecondsLeft.ReturnSingleMeasure();
        timeRemaining = sceneSwitch.ReturnTimeToSwitch();

        kissHit = new KissHit();
        kissHit.Action.Select.performed += x => GameAction();

        Debug.Log(sceneSwitch.ReturnTimeToSwitch());
        Debug.Log(measureMS);
    }


    private void OnEnable()
    {
        kissHit.Enable();
    }

    private void OnDisable()
    {
        kissHit.Disable();
    }

    // Update is called once per frame
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
            Debug.Log("Kiss");
        } else
        {
            Debug.Log("Hit");
        }
    }
}
