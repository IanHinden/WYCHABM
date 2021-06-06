using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SelectChecker : MonoBehaviour
{
    SelectArrow[] selectArrows;

    private Select select;
    private Vector2 inputMove;

    int activeArrow = 0;
    void Awake()
    {
        select = new Select();
        select.Selecting.Selecting.performed += x => setNextActiveArrow();


        selectArrows = FindObjectsOfType<SelectArrow>().OrderBy(m => m.transform.position.x).ToArray();
        for (int i = 1; i < selectArrows.Length; i++)
        {
            selectArrows[i].GetComponent<Image>().enabled = false;
        }
    }

    private void OnEnable()
    {
        select.Enable();
    }

    private void OnDisable()
    {
        select.Disable();
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
        Debug.Log(activeArrow);
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
        }
        else
        {
            activeArrow = selectArrows.Length;
        }
    }

    // Update is called once per frame
    /*void FixedUpdate()
    {
        float selectInput = select.Selecting.Selecting.ReadValue<float>();
        if (selectInput == 1)
        {
            setNextActiveArrow();
            displayCorrectArrow();
        }
        else if (selectInput == -1)
        {
            setPreviousActiveArrow();
            displayCorrectArrow();
        }
    }*/
}
