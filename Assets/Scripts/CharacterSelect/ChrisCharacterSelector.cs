using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrisCharacterSelector : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] ScoreHandler scorehandler;

    [SerializeField] GameObject OFGirlHolder;
    [SerializeField] GameObject HomeslessGirlHolder;
    [SerializeField] GameObject CongresswomanHolder;

    Animator OFGirlHolderAnim;
    Animator HomelessGirlHolderAnim;
    Animator CongresswomanHolderAnim;

    [SerializeField] GameObject OFGirl;
    [SerializeField] GameObject HomelessGirl;
    [SerializeField] GameObject Congresswoman;

    SpriteRenderer OFGirlSR;
    SpriteRenderer HomelessGirlSR;
    SpriteRenderer CongressWomanSR;

    [SerializeField] GameObject HomelessSign;
    [SerializeField] GameObject OFSign;
    [SerializeField] GameObject CongresswomanSign;

    SpriteRenderer HomelessSignSR;
    SpriteRenderer OFSignSR;
    SpriteRenderer CongresswomanSignSR;

    Animator OFGirlAnim;
    Animator HomelessGirlAnim;
    Animator CongressAnim;

    private GameControls characterSelectControls;

    private bool unlocked = false;
    private bool moved = false;
    private bool won = false;

    private int consecutiveLeftClicks = 0;
    private int selectedGirl = 0;

    private Color deselectColor = new Color32(106, 76, 76, 255);
    private Color selectColor = new Color32(255, 255, 255, 255);

    private void Awake()
    {
        characterSelectControls = new GameControls();
        characterSelectControls.Select.LeftSelect.performed += x => leftSelect();
        characterSelectControls.Select.RightSelect.performed += x => rightSelect();
        characterSelectControls.Select.Choose.performed += x => select();

        //Sprites
        OFGirlSR = OFGirl.GetComponent<SpriteRenderer>();
        HomelessGirlSR = HomelessGirl.GetComponent<SpriteRenderer>();
        CongressWomanSR = Congresswoman.GetComponent<SpriteRenderer>();

        HomelessSignSR = HomelessSign.GetComponent<SpriteRenderer>();
        OFSignSR = OFSign.GetComponent<SpriteRenderer>();
        CongresswomanSignSR = CongresswomanSign.GetComponent<SpriteRenderer>();

        //Animators
        OFGirlHolderAnim = OFGirlHolder.GetComponent<Animator>();
        HomelessGirlHolderAnim = HomeslessGirlHolder.GetComponent<Animator>();
        CongresswomanHolderAnim = CongresswomanHolder.GetComponent<Animator>();

        OFGirlAnim = OFGirl.GetComponent<Animator>();
        HomelessGirlAnim = HomelessGirl.GetComponent<Animator>();
        CongressAnim = Congresswoman.GetComponent<Animator>();

        //starAnim = threeSecondsLeft.transform.Find("CountdownImages").transform.GetChild(3).transform.GetChild(3).GetComponent<Animator>();

        //StartCoroutine(WinOrLose());
    }

    private void OnEnable()
    {
        characterSelectControls.Enable();
    }

    private void OnDisable()
    {
        characterSelectControls.Disable();
    }

    private void leftSelect()
    {
        moved = true;
        if (unlocked == false)
        {
            SelectOF();
            consecutiveLeftClicks++;
            leftCheck();
        }
        else
        {
            if (selectedGirl == 1)
            {
                selectedGirl--;
                SelectOF();
            }
            else if (selectedGirl == 2)
            {
                selectedGirl--;
                SelectCongresswoman();
            }
        }
    }

    private void rightSelect()
    {
        moved = true;
        if (unlocked == false)
        {
            SelectHomeless();
            consecutiveLeftClicks = 0;
        }
        else
        {
            if (selectedGirl == 0)
            {
                selectedGirl++;
                SelectOF();
            }
            else if (selectedGirl == 2)
            {
                selectedGirl++;
                SelectHomeless();
            }
        }
    }

    private void select()
    {
        if (moved == true)
        {
            won = true;
            scorehandler.IncrementScore();
            uihandler.WinDisplay();
            characterSelectControls.Disable();
        }

        if (unlocked == true)
        {
            won = true;
            scorehandler.IncrementScore();
            uihandler.WinDisplay();
            //uihandler.DisplayBonusScoreCard(starAnim);
        }
    }

    void SelectOF()
    {
        selectedGirl = 2;
        HomelessGirlSR.color = deselectColor;
        OFGirlSR.color = selectColor;
        CongressWomanSR.color = deselectColor;

        HomelessSignSR.color = deselectColor;
        OFSignSR.color = selectColor;
        CongresswomanSignSR.color = deselectColor; 

        //StopAllAnimations();
        //OFGirlMoves.SetBool("Breathing", true);
    }

    void SelectHomeless()
    {
        selectedGirl = 1;
        OFGirlSR.color = deselectColor;
        HomelessGirlSR.color = selectColor;
        CongressWomanSR.color = deselectColor;

        HomelessSignSR.color = selectColor;
        OFSignSR.color = deselectColor;
        CongresswomanSignSR.color = deselectColor;
        //StopAllAnimations();
        //HomelessGirlMoves.SetBool("Breathing", true);
    }

    void SelectCongresswoman()
    {
        selectedGirl = 0;
        OFGirlSR.color = deselectColor;
        HomelessGirlSR.color = deselectColor;
        CongressWomanSR.color = selectColor;

        HomelessSignSR.color = deselectColor;
        OFSignSR.color = deselectColor;
        CongresswomanSignSR.color = selectColor;
        //StopAllAnimations();
        //CongresswomanMoves.SetBool("Breathing", true);
    }

    private void leftCheck()
    {
        if (consecutiveLeftClicks == 3)
        {
            unlocked = true;
            OFGirlHolderAnim.SetTrigger("Nudge");
            HomelessGirlHolderAnim.SetTrigger("Nudge");
            CongresswomanHolderAnim.SetTrigger("Enter");
        }
    }
}
