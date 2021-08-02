using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class TweakGameplay : MonoBehaviour
{
    ControlPadButton[] controlPadButtons;

    private TweakControls tweakControls;
    private Animator redBarAnimator;

    private float currentlySelected = 0;
    private float state = 0;
    // Start is called before the first frame update
    void Awake()
    {
        controlPadButtons = FindObjectsOfType<ControlPadButton>().OrderBy(go => go.name).ToArray();

        redBarAnimator = FindObjectOfType<RedBar>().GetComponent<Animator>();
        
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
            redBarAnimator.SetTrigger("Two");
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
            redBarAnimator.SetTrigger("Three");
            RotateRight();
        }

        if (state == 5)
        {
            state++;
            redBarAnimator.SetTrigger("Six");
            RotateRight();
        }
    }

    private void downMove()
    {
        if (state == 2)
        {
            state++;
            redBarAnimator.SetTrigger("Four");
            RotateRight();
        }

        if (state == 6)
        {
            state++;
            redBarAnimator.SetTrigger("Seven");
            RotateRight();
        }
    }

    private void leftMove()
    {
        if (state == 3)
        {
            state++;
            redBarAnimator.SetTrigger("Five");
            RotateRight();
        }

        if (state == 7)
        {
            state++;
            redBarAnimator.SetTrigger("Eight");
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
