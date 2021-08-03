using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class TweakGameplay : MonoBehaviour
{
    ControlPadButton[] controlPadButtons;

    private TweakControls tweakControls;

    private FiveK fiveK;
    private TenKHundred tenKHundred;

    private Animator redBarAnimator;
    private Animator tenKAnimator;
    private Animator fiveKAnimator;
    private Animator tenKHundredAnimator;

    private MeshRenderer fiveKMesh;
    private MeshRenderer zeroMesh;
    private MeshRenderer tenKHundredMesh;

    private float currentlySelected = 0;
    private float state = 0;
    // Start is called before the first frame update
    void Awake()
    {
        controlPadButtons = FindObjectsOfType<ControlPadButton>().OrderBy(go => go.name).ToArray();

        redBarAnimator = FindObjectOfType<RedBar>().GetComponent<Animator>();
        tenKAnimator = FindObjectOfType<TenK>().GetComponent<Animator>();

        fiveK = FindObjectOfType<FiveK>();
        fiveKAnimator = fiveK.GetComponent<Animator>();
        fiveKMesh = fiveK.GetComponent<MeshRenderer>();

        zeroMesh = FindObjectOfType<Zero>().GetComponent<MeshRenderer>();

        tenKHundred = FindObjectOfType<TenKHundred>();
        tenKHundredAnimator = tenKHundred.GetComponent<Animator>();
        tenKHundredMesh = tenKHundred.GetComponent<MeshRenderer>();
        
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
            tenKAnimator.SetTrigger("Two");
            fiveKAnimator.SetTrigger("Two");
            RotateRight();
        }

        if(state == 4)
        {
            redBarAnimator.SetTrigger("Six");
            tenKAnimator.SetTrigger("Six");
            fiveKAnimator.SetTrigger("Six");
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
            tenKAnimator.SetTrigger("Three");
            fiveKAnimator.SetTrigger("Three");
            RotateRight();
        }

        if (state == 5)
        {
            redBarAnimator.SetTrigger("Seven");
            tenKAnimator.SetTrigger("Seven");
            fiveKMesh.enabled = false;
            zeroMesh.enabled = false;
            tenKHundredMesh.enabled = true;
            tenKHundredAnimator.SetTrigger("Seven");
            state++;
            RotateRight();
        }
    }

    private void downMove()
    {
        if (state == 2)
        {
            state++;
            redBarAnimator.SetTrigger("Four");
            tenKAnimator.SetTrigger("Four");
            fiveKAnimator.SetTrigger("Four");
            RotateRight();
        }

        if (state == 6)
        {
            redBarAnimator.SetTrigger("Eight");
            tenKAnimator.SetTrigger("Eight");
            tenKHundredAnimator.SetTrigger("Eight");
            state++;
            RotateRight();
        }
    }

    private void leftMove()
    {
        if (state == 3)
        {
            state++;
            redBarAnimator.SetTrigger("Five");
            tenKAnimator.SetTrigger("Five");
            fiveKAnimator.SetTrigger("Five");
            RotateRight();
        }

        if (state == 7)
        {
            state++;
            redBarAnimator.SetTrigger("Nine");
            tenKAnimator.SetTrigger("Nine");
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
