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

        StartCoroutine(GameSwitcher());
    }

    private IEnumerator GameSwitcher()
    {
        yield return null;
        meter = StartCoroutine(meterObjects.StartMeter());
        yield return new WaitForSeconds(measureMS * 3);
        meterObjects.StopRoutine();
        if(meter!= null) StopCoroutine(meter);
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
        if(meter!= null) StopCoroutine(meter);
        Debug.Log(meterObjects.getPass());
        if (firstScenario == true)
        {
            if(meterObjects.getPass() == true)
            {
                animationController.KissWin();
            } else
            {
                animationController.KissLose();
            }
        }
        else
        {
            if(meterObjects.getPass() == true)
            {
                animationController.MisstressWin();
            } else
            {

            }
        }
    }
}
