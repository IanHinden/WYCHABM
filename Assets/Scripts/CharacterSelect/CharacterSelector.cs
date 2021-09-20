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

    Animator OFGirlAnim;
    Animator HomelessGirlAnim;

    SuccessOrFail successOrFail;

    private bool moved = false;

    private int selectedJob;
    private int consecutiveLeftClicks = 0;

    Character[] characters;
    private void Awake()
    {
        characters = FindObjectsOfType<Character>();
        characterSelectControls = new CharacterSelectControls();
        OFGirl = characters[0].transform.GetChild(0).GetComponent<SpriteRenderer>();
        HomelessGirl = characters[1].transform.GetChild(0).GetComponent<SpriteRenderer>();
        threeSecondsLeft = gameObject.AddComponent<ThreeSecondsLeft>();
        sceneSwitch = FindObjectOfType<SceneSwitch>();

        OFGirlAnim = characters[0].GetComponent<Animator>();
        HomelessGirlAnim = characters[1].GetComponent<Animator>();

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
        SelectOF();
        consecutiveLeftClicks++;
        leftCheck();
    }

    private void rightSelect()
    {

        SelectHomeless();
        consecutiveLeftClicks = 0;
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
        }
    }

    void SelectOF()
    {
        HomelessGirl.color = new Color32(255, 255, 255, 255);
        OFGirl.color = new Color32(126, 126, 126, 255);
    }

    void SelectHomeless()
    {
        OFGirl.color = new Color32(255, 255, 255, 255);
        HomelessGirl.color = new Color32(126, 126, 126, 255);
    }

    IEnumerator WinOrLose()
    {
        float deadline = sceneSwitch.ReturnTimeToSwitch() - threeSecondsLeft.ReturnTimeToEnd() + (3 * threeSecondsLeft.ReturnSingleMeasure());
        yield return new WaitForSeconds(deadline);
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
