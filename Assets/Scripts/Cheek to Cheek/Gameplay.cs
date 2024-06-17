using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Gameplay : MonoBehaviour
{
    [Header("Essential Functions")]
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] ScoreHandler scorehandler;
    [SerializeField] UIHandler uiHandler;
    [SerializeField] pauseManager PM;
    [SerializeField] SteamAchievementHandler steamAchievementHandler;

    [Header("Level Objects")]
    [SerializeField] private GameControls gamecontrols;
    [SerializeField] private AnimationController animationController;

    [SerializeField] MeterObjects meterObjects;

    private float measureMS;

    private bool firstScenario = true;

    private bool firstScenarioPassed = false;
    private bool secondScenarioPassed = false;
    private bool kissAchieve = false;
    private bool tellAchieve = false;

    private float transitionTime = .3f;

    private float score = 0;

    Coroutine meter;

    void Awake()
    {
        measureMS = timefunctions.ReturnSingleMeasure();

        gamecontrols = new GameControls();
        gamecontrols.Move.Select.performed += x => GameAction();

        //StartCoroutine(GameSwitcher());
    }

    public IEnumerator GameSwitcher()
    {
        uiHandler.InstructionTextKissHit("KISS", 7);
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
        uiHandler.InstructionTextKissHit("HIT", 8);
        meterObjects.ResetMeter();
        yield return new WaitForSeconds(transitionTime);
        meter = StartCoroutine(meterObjects.StartMeter());
        firstScenario = false;
        gamecontrols.Enable();

        yield return new WaitForSeconds((measureMS * 4) - transitionTime);
         
        gamecontrols.Disable();
        if (secondScenarioPassed == false)
        {
            animationController.MisstressLose();
        }

        TotalScoreDisplay();

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
        if (PM.IsGamePaused() == false)
        {
            meterObjects.StopRoutine();
            if (meter != null) StopCoroutine(meter);
            if (firstScenario == true)
            {
                if (meterObjects.getPass() == true)
                {
                    firstScenarioPassed = true;
                    animationController.KissWin();
                    score++;

                    if(meterObjects.getKissHitAchi() == true)
                    {
                        kissAchieve = true;
                    }
                }
                else
                {
                    animationController.KissLose();
                }

                gamecontrols.Disable();
            }
            else
            {
                if (meterObjects.getPass() == true)
                {
                    secondScenarioPassed = true;
                    animationController.MisstressWin();
                    score++;

                    if(meterObjects.getKissHitAchi() == true)
                    {
                        tellAchieve = true;

                        if(kissAchieve == true && tellAchieve == true)
                        {
                            steamAchievementHandler.UnlockAchievement(1);
                        }
                    }
                }
                else
                {
                    animationController.MisstressLose();
                }
            }
        }
    }

    private void TotalScoreDisplay()
    {
        if(score == 1)
        {
            scorehandler.IncrementScore(2);
        } else if (score == 2)
        {
            scorehandler.DoubleIncrementScore(2);
        }
    }

    public void Reset()
    {
        score = 0;
        firstScenario = true;

        firstScenarioPassed = false;
        secondScenarioPassed = false;

        kissAchieve = false;
        tellAchieve = false;

        meterObjects.ResetMeter();

        animationController.Reset();
    }
}
