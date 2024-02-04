using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class TweakGameplay : MonoBehaviour
{
    [Header("Essential Functions")]
    [SerializeField] ScoreHandler scorehandler;
    [SerializeField] UIHandler uihandler;
    [SerializeField] TimeFunctions timefunctions;

    [SerializeField] TweakSFX tweakSFX;

    [Header("Game Elements")]
    [SerializeField] GameObject redBar;
    [SerializeField] GameObject blueBar;

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
    Coroutine rotateWinCo;

    private bool won = false;
    private bool firstBlink = true;

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
                tweakSFX.PlayBalloon(1);
                state++;
                redBarAnimator.SetTrigger("Two");
                blueBarAnimator.SetTrigger("Two");
                tenKAnimator.SetTrigger("Two");
                fiveKAnimator.SetTrigger("Two");
                RotateRight();
            }

            if (state == 4)
            {
                tweakSFX.PlayBalloon(3);
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
                tweakSFX.PlayBalloon(1.5f);
                state++;
                redBarAnimator.SetTrigger("Three");
                blueBarAnimator.SetTrigger("Three");
                tenKAnimator.SetTrigger("Three");
                fiveKAnimator.SetTrigger("Three");
                RotateRight();
            }

            if (state == 5)
            {
                tweakSFX.PlayBalloon(3);
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
                tweakSFX.PlayBalloon(2);
                state++;
                redBarAnimator.SetTrigger("Four");
                blueBarAnimator.SetTrigger("Four");
                tenKAnimator.SetTrigger("Four");
                fiveKAnimator.SetTrigger("Four");
                RotateRight();
            }

            if (state == 6)
            {
                tweakSFX.PlayBalloon(3);
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
                tweakSFX.PlayBalloon(2.5f);
                state++;
                redBarAnimator.SetTrigger("Five");
                blueBarAnimator.SetTrigger("Five");
                tenKAnimator.SetTrigger("Five");
                fiveKAnimator.SetTrigger("Five");
                RotateRight();
            }

            if (state == 7)
            {
                tweakSFX.PlayBalloon(3);
                state++;
                won = true;
                scorehandler.IncrementScore();
                uihandler.WinDisplay();
                rotateWinCo = StartCoroutine(RotateWin());
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
        firstBlink = false;

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

    private IEnumerator RotateWin()
    {
        while (won == true) {
            RotateRight();
            yield return new WaitForSeconds(.3f);
        }
    }

    private void displayCorrectArrow()
    {
        if (controlPadButtons != null)
        {
            if (currentBlink != null) StopCoroutine(currentBlink);
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
                    if (state != 0) currentBlink = StartCoroutine(Blink(currentSR));
                }
            }
        }
    }

    IEnumerator Blink(SpriteRenderer currentSR)
    {
        while (true)
        {
            currentSR.enabled = false;
            yield return new WaitForSeconds(.3f);

            currentSR.enabled = true;
            if (firstBlink == true)
            {
                tweakSFX.PlayBlink();
            }
            yield return new WaitForSeconds(.3f);
        }
    }

    private IEnumerator StartBlink()
    {
        yield return new WaitForSeconds(.7f);
        currentBlink = StartCoroutine(Blink(controlPadButtons[0].GetComponent<SpriteRenderer>()));
    }

    public IEnumerator WinOrLose()
    {
        StartCoroutine(StartBlink());
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(7));

        if(won == false)
        {
            uihandler.LoseDisplay();
        }
    }

    public void Reset()
    {
        redBar.transform.localScale = new Vector3(0.655565f, 1.389891f, 1);
        redBar.transform.localPosition = new Vector3(2.04f, -9.26f, 0);
        blueBar.transform.localScale = new Vector3(0.4398549f, 1.55402f, 1);
        blueBar.transform.localPosition = new Vector3(4.623f, -9.2f, 0);
        if(rotateWinCo != null) StopCoroutine(rotateWinCo);
        currentlySelected = 0;
        state = 0;
        displayCorrectArrow();
        won = false;
        firstBlink = true;
    }
}
