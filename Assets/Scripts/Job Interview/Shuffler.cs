using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Shuffler : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] ScoreHandler scorehandler;
    [SerializeField] CameraLogic cameraLogic;
    [SerializeField] pauseManager PM;

    [SerializeField] JobInterviewAnimationController jobInterviewAnimationController;
    [SerializeField] JobInterviewSFXController jobInterviewSFXController;

    [SerializeField] GameObject fingers;
    int activeFinger = 0;

    private GameControls gamecontrols;

    private bool pressed = false;

    void Awake()
    {
        gamecontrols = new GameControls();

        gamecontrols.Select.LeftSelect.performed += x => setPreviousActiveFinger();
        gamecontrols.Select.UpSelect.performed += x => setPreviousActiveFinger();
        gamecontrols.Select.RightSelect.performed += x => setNextActiveFinger();
        gamecontrols.Select.DownSelect.performed += x => setNextActiveFinger();
        gamecontrols.Select.Choose.performed += x => Select();

        //StartCoroutine(WinOrLose());
    }

    private void OnEnable()
    {
        gamecontrols.Enable();
    }

    private void OnDisable()
    {
        gamecontrols.Disable();
    }

    public void displayCorrectFinger()
    {
        jobInterviewSFXController.PlayHighlight();
        for (int i = 0; i < fingers.transform.childCount; i++)
        {
            if (i != activeFinger)
            {
                fingers.transform.GetChild(i).GetComponent<Image>().enabled = false;
            }
            else
            {
                fingers.transform.GetChild(i).GetComponent<Image>().enabled = true;
            }
        }
        AnimateProperBubble();
    }

    public void setNextActiveFinger()
    {
        if (PM.IsGamePaused() == false)
        {
            if (activeFinger != fingers.transform.childCount - 1)
            {
                activeFinger++;
                displayCorrectFinger();
            }
            else
            {
                activeFinger = 0;
                displayCorrectFinger();
            }
        }
    }

    public void setPreviousActiveFinger()
    {
        if (PM.IsGamePaused() == false)
        {
            if (activeFinger != 0)
            {
                activeFinger--;
                displayCorrectFinger();
            }
            else
            {
                activeFinger = fingers.transform.childCount - 1;
                displayCorrectFinger();
            }
        }
    }

    private void AnimateProperBubble()
    {
        if(activeFinger == 0)
        {
            jobInterviewAnimationController.SetQualifiedBubble();
        }

        if(activeFinger == 1)
        {
            jobInterviewAnimationController.SetCEOBubble();
        }

        if(activeFinger == 2)
        {
            jobInterviewAnimationController.SetDegreeBubble();
        }
    }

    public IEnumerator WinOrLose()
    {
        AnimateProperBubble();
        StartCoroutine(cameraLogic.moveToX(new Vector3(5.9f, 10.59f, -10), .5f));
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));
        if (pressed == false)
        {
            uihandler.LoseDisplay();
        }
    }

    private void Select()
    {
        if (PM.IsGamePaused() == false)
        {
            pressed = true;
            gamecontrols.Disable();
            if (activeFinger == 1)
            {
                scorehandler.IncrementScore(2);
                uihandler.WinDisplay();
            }
            else
            {
                uihandler.LoseDisplay();
            }
        }
    }

    public void Reset()
    {
        pressed = false;
        activeFinger = 0;

        for (int i = 0; i < fingers.transform.childCount; i++)
        {
            if (i != 0)
            {
                fingers.transform.GetChild(i).GetComponent<Image>().enabled = false;
            }
            else
            {
                fingers.transform.GetChild(i).GetComponent<Image>().enabled = true;
            }
        }
    }
}
