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

    private float measureMS;

    private bool firstScenario = true;

    void Awake()
    {
        measureMS = timefunctions.ReturnSingleMeasure();

        gamecontrols = new GameControls();
        gamecontrols.Move.Select.performed += x => GameAction();

        StartCoroutine(GameSwitcher());
    }

    private IEnumerator GameSwitcher()
    {
        yield return new WaitForSeconds(measureMS * 3);
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
        if (firstScenario == true)
        {
            Debug.Log("First game");
        }
        else
        {
            Debug.Log("Second game");
        }
    }
}
