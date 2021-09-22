using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    private CharacterSelectControls characterSelectControls;
    ThreeSecondsLeft threeSecondsLeft;
    SceneSwitch sceneSwitch;

    SpriteRenderer OFGirl;
    SpriteRenderer HomelessGirl;
    SpriteRenderer CongressWoman;

    Animator OFGirlAnim;
    Animator HomelessGirlAnim;
    Animator CongressAnim;

    SuccessOrFail successOrFail;

    private bool unlocked = false;
    private bool moved = false;

    private int selectedJob;
    private int consecutiveLeftClicks = 0;
    private int selectedGirl = 0;

    Character[] characters;
    private void Awake()
    {
        characters = FindObjectsOfType<Character>();
        characterSelectControls = new CharacterSelectControls();
        OFGirl = characters[0].transform.GetChild(0).GetComponent<SpriteRenderer>();
        HomelessGirl = characters[1].transform.GetChild(0).GetComponent<SpriteRenderer>();
        CongressWoman = FindObjectOfType<Congress>().transform.GetChild(0).GetComponent<SpriteRenderer>();
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
        sceneSwitch = FindObjectOfType<SceneSwitch>();

        OFGirlAnim = characters[0].GetComponent<Animator>();
        HomelessGirlAnim = characters[1].GetComponent<Animator>();
        CongressAnim = FindObjectOfType<Congress>().GetComponent<Animator>();

        characterSelectControls.CharacterSelect.LeftSelect.performed += x => leftSelect();
        characterSelectControls.CharacterSelect.RightSelect.performed += x => rightSelect();
        characterSelectControls.CharacterSelect.Select.performed += x => select();

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

    private void leftSelect()
    {
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
        moved = true;
        characterSelectControls.Disable();
    }

    private void leftCheck()
    {
        if(consecutiveLeftClicks == 3)
        {
            OFGirlAnim.SetTrigger("First");
            HomelessGirlAnim.SetTrigger("First");
        }

        if(consecutiveLeftClicks == 8)
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
        float deadline = sceneSwitch.ReturnTimeToSwitch() - threeSecondsLeft.ReturnTimeToEnd() + (3 * threeSecondsLeft.ReturnSingleMeasure());
        yield return new WaitForSeconds(deadline);
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        characterSelectControls.Disable();
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
