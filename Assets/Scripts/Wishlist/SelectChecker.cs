using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChecker : MonoBehaviour
{
    SelectArrow[] selectArrows;
    int activeArrow = 2;
    void Start()
    {
        selectArrows = FindObjectsOfType<SelectArrow>();
    }

    public void displayCorrectArrow()
    {
        for(int i = 0; i < 3; i++)
        {
            if (i != activeArrow) {
                Debug.Log(selectArrows[i]);
                selectArrows[i].enabled = false;
            }
        }
    }

    public void setNextActiveArrow()
    {
        if(activeArrow != 3)
        {
            activeArrow++;
        } else
        {
            activeArrow = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        displayCorrectArrow();
    }
}
