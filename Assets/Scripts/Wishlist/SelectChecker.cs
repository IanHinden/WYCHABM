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

    [SerializeField] GameObject arrows;

    private GameControls gamecontrols;

    int activeArrow = 0;
    bool selected = false;
    void Awake()
    {
        gamecontrols = new GameControls();

        gamecontrols.Select.DownSelect.performed += x => setNextActiveArrow();
        gamecontrols.Select.UpSelect.performed += x => setPreviousActiveArrow();
        gamecontrols.Select.Choose.performed += x => selectItem();


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

    public void selectItem()
    {
        selected = true;
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
        for(int i = 0; i < arrows.transform.childCount; i++)
        {
            if (i != activeArrow) {
                arrows.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
            } else
            {
                arrows.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    public void setNextActiveArrow()
    {
        if(activeArrow != arrows.transform.childCount - 1)
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
            activeArrow = arrows.transform.childCount - 1;
            displayCorrectArrow();
        }
    }

    public IEnumerator WinOrLose()
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(7));

        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        if (selected == true)
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

    public void Reset()
    {
        selected = false;
        activeArrow = 0;
        displayCorrectArrow();
    }
}
