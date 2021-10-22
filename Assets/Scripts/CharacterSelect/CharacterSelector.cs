using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    private CharacterSelectControls characterSelectControls;
    ThreeSecondsLeft threeSecondsLeft;

    SpriteRenderer OFGirl;
    SpriteRenderer HomelessGirl;
    SpriteRenderer CongressWoman;

    Animator OFGirlAnim;
    Animator HomelessGirlAnim;
    Animator CongressAnim;
    Animator starAnim;

    private bool unlocked = false;
    private bool moved = false;
    private bool won = false;

    private int consecutiveLeftClicks = 0;
    private int selectedGirl = 0;

    Character[] characters;
    private void Awake()
    {
        characterSelectControls = new CharacterSelectControls();
        characterSelectControls.CharacterSelect.LeftSelect.performed += x => leftSelect();
        characterSelectControls.CharacterSelect.RightSelect.performed += x => rightSelect();
        characterSelectControls.CharacterSelect.Select.performed += x => select();

        characters = FindObjectsOfType<Character>();
        
        OFGirl = characters[0].transform.GetChild(0).GetComponent<SpriteRenderer>();
        HomelessGirl = characters[1].transform.GetChild(0).GetComponent<SpriteRenderer>();
        CongressWoman = FindObjectOfType<Congress>().transform.GetChild(0).GetComponent<SpriteRenderer>();
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();

        OFGirlAnim = characters[0].GetComponent<Animator>();
        HomelessGirlAnim = characters[1].GetComponent<Animator>();
        CongressAnim = FindObjectOfType<Congress>().GetComponent<Animator>();

        starAnim = threeSecondsLeft.transform.Find("CountdownImages").transform.GetChild(3).transform.GetChild(3).GetComponent<Animator>();

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

    private void leftSelect()
    {
        moved = true;
        if (unlocked == false)
        {
            SelectOF();
            consecutiveLeftClicks++;
            leftCheck();
        } else
        {
            if(selectedGirl == 2)
            {
                selectedGirl--;
                SelectOF();
            } else if (selectedGirl == 1)
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
        } else
        {
            if (selectedGirl == 0)
            {
                selectedGirl++;
                SelectOF();
            }
            else if (selectedGirl == 1)
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
            threeSecondsLeft.DisplayScoreCard();
            threeSecondsLeft.WinDisplay();
            characterSelectControls.Disable();
        }

        if(unlocked == true)
        {
            threeSecondsLeft.DisplayBonusScoreCard(starAnim);
        }
    }

    private void leftCheck()
    {
        if(consecutiveLeftClicks == 3)
        {
            OFGirlAnim.SetTrigger("First");
            HomelessGirlAnim.SetTrigger("First");
        }

        if(consecutiveLeftClicks == 6)
        {
            OFGirlAnim.SetTrigger("Second");
            HomelessGirlAnim.SetTrigger("Second");
            CongressAnim.SetTrigger("First");

            unlocked = true;
            SelectCongresswoman();
        }
    }

    void SelectOF()
    {
        HomelessGirl.color = new Color32(255, 255, 255, 255);
        OFGirl.color = new Color32(126, 126, 126, 255);
        CongressWoman.color = new Color32(126, 126, 126, 255);
    }

    void SelectHomeless()
    {
        OFGirl.color = new Color32(255, 255, 255, 255);
        HomelessGirl.color = new Color32(126, 126, 126, 255);
        CongressWoman.color = new Color32(126, 126, 126, 255);
    }

    void SelectCongresswoman()
    {
        OFGirl.color = new Color32(126, 126, 126, 255);
        HomelessGirl.color = new Color32(126, 126, 126, 255);
        CongressWoman.color = new Color32(255, 255, 255, 255);
    }

    IEnumerator WinOrLose()
    {
        float deadline = threeSecondsLeft.ReturnTimeToEnd() + threeSecondsLeft.ReturnSingleMeasure();
        yield return new WaitForSeconds(deadline);
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        if (won == false)
        {
            characterSelectControls.Disable();
            if (unlocked)
            {
                threeSecondsLeft.DisplayBonusScoreCard(starAnim);
            }
            else if (moved)
            {
                threeSecondsLeft.DisplayScoreCard();
                threeSecondsLeft.WinDisplay();
            }
            else
            {
                threeSecondsLeft.LoseDisplay();
            }
        }
    }
}
