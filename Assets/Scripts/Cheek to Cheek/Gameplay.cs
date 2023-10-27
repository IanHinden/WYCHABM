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

    private bool firstScenarioPassed = false;
    private bool secondScenarioPassed = false;

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
        yield return new WaitForSeconds(measureMS * 2);

        if(firstScenarioPassed == false)
        {
            animationController.KissLose();
        }

        yield return new WaitForSeconds(measureMS * 1);

        meterObjects.StopRoutine();
        if(meter!= null) StopCoroutine(meter);
        animationController.SwitchScene();
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
        if (firstScenario == true)
        {
            if(meterObjects.getPass() == true)
            {
                firstScenarioPassed = true;
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
                animationController.MisstressLose();
            }
        }
    }
}
