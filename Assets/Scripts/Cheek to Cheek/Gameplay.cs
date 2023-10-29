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
        yield return new WaitForSeconds(measureMS * 3);

        gamecontrols.Disable();
        if (firstScenarioPassed == false)
        {
            animationController.KissLose();
        }

        meterObjects.StopRoutine();
        if(meter!= null) StopCoroutine(meter);

        animationController.SwitchScene();
        meterObjects.ResetMeter();
        yield return new WaitForSeconds(.3f);
        meter = StartCoroutine(meterObjects.StartMeter());
        firstScenario = false;
        gamecontrols.Enable();

        yield return new WaitForSeconds((measureMS * 2) + .7f);
         
        gamecontrols.Disable();
        if (secondScenarioPassed == false)
        {
            animationController.MisstressLose();
        }

        meterObjects.StopRoutine();

        gamecontrols.Disable();
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

            gamecontrols.Disable();
        }
        else
        {
            if(meterObjects.getPass() == true)
            {
                secondScenarioPassed = true;
                animationController.MisstressWin();
            } else
            {
                animationController.MisstressLose();
            }
        }
    }
}
