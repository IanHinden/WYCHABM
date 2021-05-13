﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    private CharacterSelectControls characterSelectControls;
    SpriteRenderer OFGirl;
    SpriteRenderer HomelessGirl;
    SuccessOrFail successOrFail;

    private bool moved = false;

    Character[] characters;
    private void Awake()
    {
        characters = FindObjectsOfType<Character>();
        characterSelectControls = new CharacterSelectControls();
        OFGirl = characters[0].transform.GetChild(0).GetComponent<SpriteRenderer>();
        HomelessGirl = characters[1].transform.GetChild(0).GetComponent<SpriteRenderer>();

        successOrFail = gameObject.AddComponent<SuccessOrFail>();
        StartCoroutine(WinOrLose());
    }

    private void OnEnable()
    {
        characterSelectControls.Enable();
    }

    private void OnDisable()
    {
        characterSelectControls.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float selectInput = characterSelectControls.CharacterSelect.Selection.ReadValue<float>();
        if(selectInput == 1)
        {
            SelectOF();
        } else if (selectInput == -1)
        {
            SelectHomeless();
        }
    }

    void SelectOF()
    {
        moved = true;
        OFGirl.color = new Color32(255, 255, 255, 255);
        HomelessGirl.color = new Color32(126, 126, 126, 255);
    }

    void SelectHomeless()
    {
        moved = true;
        HomelessGirl.color = new Color32(255, 255, 255, 255);
        OFGirl.color = new Color32(126, 126, 126, 255);
    }

    IEnumerator WinOrLose()
    {
        yield return new WaitForSeconds(4f);
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        if (moved)
        {
            successOrFail.WinDisplay();
        }
        else
        {
            successOrFail.LoseDisplay();
        }
    }
}
