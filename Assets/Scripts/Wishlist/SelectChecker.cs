using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SelectChecker : MonoBehaviour
{
    SelectArrow[] selectArrows;
    SuccessOrFail successOrFail;
    ThreeSecondsLeft threeSecondsLeft;

    private Select select;

    int activeArrow = 0;
    void Awake()
    {
        select = new Select();
        successOrFail = gameObject.AddComponent<SuccessOrFail>();
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();

        select.Selecting.DownSelect.performed += x => setNextActiveArrow();
        select.Selecting.UpSelect.performed += x => setPreviousActiveArrow();
        select.Selecting.Select.performed += x => selectItem();


        selectArrows = FindObjectsOfType<SelectArrow>().OrderBy(m => m.transform.position.x).ToArray();
        for (int i = 1; i < selectArrows.Length; i++)
        {
            selectArrows[i].GetComponent<Image>().enabled = false;
        }

        StartCoroutine(WinOrLose());
    }

    private void OnEnable()
    {
        select.Enable();
    }

    private void OnDisable()
    {
        select.Disable();
    }

    public void selectItem()
    {
        if(activeArrow == 2)
        {
            successOrFail.WinDisplay();
            select.Disable();
            
        } else
        {
            successOrFail.LoseDisplay();
            select.Disable();
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
        float timeToEnd = (2 * threeSecondsLeft.ReturnTimeToEnd()) - threeSecondsLeft.ReturnSingleMeasure();

        while (timeToEnd > 0)
        {
            timeToEnd -= Time.deltaTime;
            yield return null;
        }

        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        if (activeArrow == 2)
        {
            threeSecondsLeft.DisplayScoreCard();
            successOrFail.WinDisplay();
            select.Disable();

        }
        else
        {
            successOrFail.LoseDisplay();
            select.Disable();
        }
    }
}
