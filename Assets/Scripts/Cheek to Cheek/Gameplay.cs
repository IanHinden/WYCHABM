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
    [SerializeField] private GameControls gamecontrols;
    [SerializeField] private AnimationController animationController;

    [SerializeField] MeterObjects meterObjects;

    private float measureMS;

    private bool firstScenario = true;

    Coroutine meter;

    void Awake()
    {
        measureMS = timefunctions.ReturnSingleMeasure();

        gamecontrols = new GameControls();
        gamecontrols.Move.Select.performed += x => GameAction();

        meter = StartCoroutine(meterObjects.StartMeter());
        StartCoroutine(GameSwitcher());
    }

    private IEnumerator GameSwitcher()
    {
        yield return new WaitForSeconds(measureMS * 3);
        meterObjects.ResetMeter();
        meter = StartCoroutine(meterObjects.StartMeter());
        firstScenario = false;
    }


    private void OnEnable()
    {
        gamecontrols.Enable();
    }

    private void OnDisable()
    {
        gamecontrols.Disable();
    }

    private void GameAction()
    {
        meterObjects.StopRoutine();
        StopCoroutine(meter);
        Debug.Log(meterObjects.getPass());
        /*if (firstScenario == true)
        {
            Debug.Log("First game");
        }
        else
        {
            Debug.Log("Second game");
        }*/
    }
}
