using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class TweakGameplay : MonoBehaviour
{
    ControlPadButton[] controlPadButtons;

    private TweakControls tweakControls;

    private float currentlySelected = 0;
    private float state = 0;
    // Start is called before the first frame update
    void Awake()
    {
        controlPadButtons = FindObjectsOfType<ControlPadButton>().OrderBy(go => go.name).ToArray();
        
        tweakControls = new TweakControls();
        tweakControls.Move.UpArrow.performed += x => upMove();
        tweakControls.Move.RightArrow.performed += x => rightMove();
        tweakControls.Move.DownArrow.performed += x => downMove();
        tweakControls.Move.LeftArrow.performed += x => leftMove();
    }

    private void upMove()
    {
        if (state == 0)
        {
            state++;
            RotateRight();
        }

        if(state == 4)
        {
            state++;
            RotateRight();
        }
    }

    private void rightMove()
    {
        if (state == 1)
        {
            state++;
            RotateRight();
        }

        if (state == 5)
        {
            state++;
            RotateRight();
        }
    }

    private void downMove()
    {
        if (state == 2)
        {
            state++;
            RotateRight();
        }

        if (state == 6)
        {
            state++;
            RotateRight();
        }
    }

    private void leftMove()
    {
        if (state == 3)
        {
            state++;
            RotateRight();
        }

        if (state == 7)
        {
            state++;
            RotateRight();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        tweakControls.Enable();
    }

    private void OnDisable()
    {
        tweakControls.Disable();
    }

    private void RotateRight()
    {
        if(currentlySelected == 3)
        {
            currentlySelected = 0;
            displayCorrectArrow();
        } else
        {
            currentlySelected++;
            displayCorrectArrow();
        }
    }

    private void displayCorrectArrow()
    {
        for (int i = 0; i < controlPadButtons.Length; i++)
        {
            if (i != currentlySelected)
            {
                controlPadButtons[i].GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                controlPadButtons[i].GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
