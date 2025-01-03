﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrisCharacterSelector : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] ScoreHandler scorehandler;
    [SerializeField] pauseManager PM;

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

    [SerializeField] GameObject OFSelector;
    [SerializeField] GameObject HomelessSelector;

    SpriteRenderer OFSelectorSR;
    SpriteRenderer HomelessSelectorSR;

    [SerializeField] CharacterSelectSFXController characterSelectSFXController;

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

        OFSelectorSR = OFSelector.GetComponent<SpriteRenderer>();
        HomelessSelectorSR = HomelessSelector.GetComponent<SpriteRenderer>();

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
        if (PM.IsGamePaused() == false)
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
    }

    private void rightSelect()
    {
        if (PM.IsGamePaused() == false)
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
    }

    private void select()
    {
        if (PM.IsGamePaused() == false)
        {
            characterSelectSFXController.PlayConfirm();
            if (moved == true)
            {
                won = true;
                scorehandler.IncrementScore(1);
                uihandler.WinDisplay();
                characterSelectControls.Disable();
            }

            if (unlocked == true)
            {
                //won = true;
                //scorehandler.IncrementScore();
                //uihandler.WinDisplay();
                //uihandler.DisplayBonusScoreCard(starAnim);
                scorehandler.IncrementBonusScore(2);
            }

            if (selectedGirl == 2)
            {
                StartCoroutine(characterSelectSFXController.PlayOFSelected());
            }
            else if (selectedGirl == 1)
            {
                StartCoroutine(characterSelectSFXController.PlayHomelessSelected());
            }
            else if (selectedGirl == 0)
            {
                StartCoroutine(characterSelectSFXController.PlayCongresswomanSelected());
            }
        }
    }

    void SelectOF()
    {
        characterSelectSFXController.PlayHighlight();
        selectedGirl = 2;
        HomelessGirlSR.color = deselectColor;
        OFGirlSR.color = selectColor;
        CongressWomanSR.color = deselectColor;

        HomelessSignSR.color = deselectColor;
        OFSignSR.color = selectColor;
        CongresswomanSignSR.color = deselectColor;

        OFSelectorSR.enabled = true;
        HomelessSelectorSR.enabled = false;

        //StopAllAnimations();
        //OFGirlMoves.SetBool("Breathing", true);
    }

    void SelectHomeless()
    {
        if (selectedGirl != 1)
        {
            characterSelectSFXController.PlayHighlight();
            selectedGirl = 1;
            OFGirlSR.color = deselectColor;
            HomelessGirlSR.color = selectColor;
            CongressWomanSR.color = deselectColor;

            HomelessSignSR.color = selectColor;
            OFSignSR.color = deselectColor;
            CongresswomanSignSR.color = deselectColor;

            OFSelectorSR.enabled = false;
            HomelessSelectorSR.enabled = true;
            //StopAllAnimations();
            //HomelessGirlMoves.SetBool("Breathing", true);
        }
    }

    void SelectCongresswoman()
    {
        if (selectedGirl != 0)
        {
            characterSelectSFXController.PlayHighlight();
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
