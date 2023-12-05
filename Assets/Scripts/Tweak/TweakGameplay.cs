using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class TweakGameplay : MonoBehaviour
{
    [SerializeField] ScoreHandler scorehandler;
    [SerializeField] UIHandler uihandler;
    [SerializeField] TimeFunctions timefunctions;
    ControlPadButton[] controlPadButtons;

    private GameControls gamecontrols;

    private FiveK fiveK;
    private TenKHundred tenKHundred;

    private Animator redBarAnimator;
    private Animator blueBarAnimator;
    private Animator tenKAnimator;
    private Animator fiveKAnimator;
    private Animator tenKHundredAnimator;

    private MeshRenderer fiveKMesh;
    private MeshRenderer zeroMesh;
    private MeshRenderer tenKHundredMesh;

    private float currentlySelected = 0;
    private float state = 0;

    Coroutine currentBlink;

    private bool won = false;
    // Start is called before the first frame update
    void Awake()
    {
        controlPadButtons = FindObjectsOfType<ControlPadButton>().OrderBy(go => go.name).ToArray();

        redBarAnimator = FindObjectOfType<RedBar>().GetComponent<Animator>();
        blueBarAnimator = FindObjectOfType<BlueBar>().GetComponent<Animator>();
        tenKAnimator = FindObjectOfType<TenK>().GetComponent<Animator>();

        fiveK = FindObjectOfType<FiveK>();
        fiveKAnimator = fiveK.GetComponent<Animator>();
        fiveKMesh = fiveK.GetComponent<MeshRenderer>();

        zeroMesh = FindObjectOfType<Zero>().GetComponent<MeshRenderer>();

        tenKHundred = FindObjectOfType<TenKHundred>();
        tenKHundredAnimator = tenKHundred.GetComponent<Animator>();
        tenKHundredMesh = tenKHundred.GetComponent<MeshRenderer>();

        gamecontrols = new GameControls();
        gamecontrols.Move.Directions.performed += x => upMove(x.ReadValue<Vector2>());

        //StartCoroutine(WinOrLose());
    }

    private void upMove(Vector2 movement)
    {
        if (movement.y == 1)
        {
            if (state == 0)
            {
                state++;
                redBarAnimator.SetTrigger("Two");
                blueBarAnimator.SetTrigger("Two");
                tenKAnimator.SetTrigger("Two");
                fiveKAnimator.SetTrigger("Two");
                RotateRight();
            }

            if (state == 4)
            {
                redBarAnimator.SetTrigger("Six");
                blueBarAnimator.SetTrigger("Six");
                tenKAnimator.SetTrigger("Six");
                fiveKAnimator.SetTrigger("Six");
                state++;
                RotateRight();
            }
        }

        if(movement.x == 1)
        {
            if (state == 1)
            {
                state++;
                redBarAnimator.SetTrigger("Three");
                blueBarAnimator.SetTrigger("Three");
                tenKAnimator.SetTrigger("Three");
                fiveKAnimator.SetTrigger("Three");
                RotateRight();
            }

            if (state == 5)
            {
                redBarAnimator.SetTrigger("Seven");
                blueBarAnimator.SetTrigger("Seven");
                tenKAnimator.SetTrigger("Seven");
                fiveKMesh.enabled = false;
                zeroMesh.enabled = false;
                tenKHundredMesh.enabled = true;
                tenKHundredAnimator.SetTrigger("Seven");
                state++;
                RotateRight();
            }
        }

        if (movement.y == -1)
        {
            if (state == 2)
            {
                state++;
                redBarAnimator.SetTrigger("Four");
                blueBarAnimator.SetTrigger("Four");
                tenKAnimator.SetTrigger("Four");
                fiveKAnimator.SetTrigger("Four");
                RotateRight();
            }

            if (state == 6)
            {
                redBarAnimator.SetTrigger("Eight");
                blueBarAnimator.SetTrigger("Eight");
                tenKAnimator.SetTrigger("Eight");
                tenKHundredAnimator.SetTrigger("Eight");
                state++;
                RotateRight();
            }
        }
        if (movement.x == -1)
        {
            if (state == 3)
            {
                state++;
                redBarAnimator.SetTrigger("Five");
                blueBarAnimator.SetTrigger("Five");
                tenKAnimator.SetTrigger("Five");
                fiveKAnimator.SetTrigger("Five");
                RotateRight();
            }

            if (state == 7)
            {
                state++;
                won = true;
                scorehandler.IncrementScore();
                uihandler.WinDisplay();
                RotateRight();
                //Instead of rotating right, maybe animate win?
            }
        }

    }

    private void OnEnable()
    {
        gamecontrols.Enable();
    }

    private void OnDisable()
    {
        gamecontrols.Disable();
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
        if(currentBlink != null) StopCoroutine(currentBlink);
        for (int i = 0; i < controlPadButtons.Length; i++)
        {
            if (i != currentlySelected)
            {
                controlPadButtons[i].GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                SpriteRenderer currentSR = controlPadButtons[i].GetComponent<SpriteRenderer>();
                currentSR.enabled = true;
                currentBlink = StartCoroutine(Blink(currentSR));

            }
        }
    }

    IEnumerator Blink(SpriteRenderer currentSR)
    {
        while (true)
        {
            currentSR.enabled = false;
            yield return new WaitForSeconds(.1f);

            currentSR.enabled = true;
            yield return new WaitForSeconds(.1f);
        }
    }

    public IEnumerator WinOrLose()
    {
        currentBlink = StartCoroutine(Blink(controlPadButtons[0].GetComponent<SpriteRenderer>()));
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(7));

        if(won == false)
        {
            uihandler.LoseDisplay();
        }
    }

    public void Reset()
    {
        won = false;
    }
}
