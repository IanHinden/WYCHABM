using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SelectChecker : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;
    [SerializeField] ScoreHandler scorehandler;
    [SerializeField] TimeFunctions timefunctions;

    SelectArrow[] selectArrows;

    private GameControls gamecontrols;

    int activeArrow = 0;
    void Awake()
    {
        gamecontrols = new GameControls();

        gamecontrols.Select.DownSelect.performed += x => setNextActiveArrow();
        gamecontrols.Select.UpSelect.performed += x => setPreviousActiveArrow();
        gamecontrols.Select.Choose.performed += x => selectItem();


        selectArrows = FindObjectsOfType<SelectArrow>().OrderBy(m => m.transform.position.x).ToArray();
        for (int i = 1; i < selectArrows.Length; i++)
        {
            selectArrows[i].GetComponent<Image>().enabled = false;
        }

        StartCoroutine(WinOrLose());
    }

    private void OnEnable()
    {
        gamecontrols.Enable();
    }

    private void OnDisable()
    {
        gamecontrols.Disable();
    }

    public void selectItem()
    {
        if(activeArrow == 2)
        {
            scorehandler.IncrementScore();
            uihandler.WinDisplay();
            gamecontrols.Disable();
            
        } else
        {
            uihandler.LoseDisplay();
            gamecontrols.Disable();
        }
    }

    public void displayCorrectArrow()
    {
        for(int i = 0; i < selectArrows.Length; i++)
        {
            if (i != activeArrow) {
                selectArrows[i].GetComponent<Image>().enabled = false;
            } else
            {
                selectArrows[i].GetComponent<Image>().enabled = true;
            }
        }
    }

    public void setNextActiveArrow()
    {
        if(activeArrow != selectArrows.Length - 1)
        {
            activeArrow++;
            displayCorrectArrow();
        } else
        {
            activeArrow = 0;
            displayCorrectArrow();
        }
    }

    public void setPreviousActiveArrow()
    {
        if (activeArrow != 0)
        {
            activeArrow--;
            displayCorrectArrow();
        }
        else
        {
            activeArrow = selectArrows.Length - 1;
            displayCorrectArrow();
        }
    }

    IEnumerator WinOrLose()
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(5));

        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        if (activeArrow == 2)
        {
            scorehandler.IncrementScore();
            uihandler.WinDisplay();
            gamecontrols.Disable();

        }
        else
        {
            uihandler.LoseDisplay();
            gamecontrols.Disable();
        }
    }
}
