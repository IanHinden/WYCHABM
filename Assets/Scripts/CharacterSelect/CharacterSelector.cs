using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] ScoreHandler scorehandler;

    [SerializeField] GameObject CongressSpotlight;
    [SerializeField] GameObject OFSpotlight;
    [SerializeField] GameObject HomelessSpotlight;

    private GameControls characterSelectControls;

    SpriteRenderer OFGirl;
    SpriteRenderer HomelessGirl;
    SpriteRenderer CongressWoman;

    Animator OFGirlAnim;
    Animator HomelessGirlAnim;
    Animator CongressAnim;
    //Animator starAnim;

    private bool unlocked = false;
    private bool moved = false;
    private bool won = false;

    private int consecutiveLeftClicks = 0;
    private int selectedGirl = 0;

    Character[] characters;
    GameObject[] spotlight = new GameObject[3];
    private void Awake()
    {
        characterSelectControls = new GameControls();
        characterSelectControls.Select.LeftSelect.performed += x => leftSelect();
        characterSelectControls.Select.RightSelect.performed += x => rightSelect();
        characterSelectControls.Select.Choose.performed += x => select();

        characters = FindObjectsOfType<Character>();
        
        OFGirl = characters[0].transform.GetChild(0).GetComponent<SpriteRenderer>();
        HomelessGirl = characters[1].transform.GetChild(0).GetComponent<SpriteRenderer>();
        CongressWoman = FindObjectOfType<Congress>().transform.GetChild(0).GetComponent<SpriteRenderer>();

        OFGirlAnim = characters[0].GetComponent<Animator>();
        HomelessGirlAnim = characters[1].GetComponent<Animator>();
        CongressAnim = FindObjectOfType<Congress>().GetComponent<Animator>();

        spotlight[0] = CongressSpotlight;
        spotlight[1] = OFSpotlight;
        spotlight[2] = HomelessSpotlight;

        //starAnim = threeSecondsLeft.transform.Find("CountdownImages").transform.GetChild(3).transform.GetChild(3).GetComponent<Animator>();

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
            scorehandler.IncrementScore();
            uihandler.WinDisplay();
            characterSelectControls.Disable();
        }

        if(unlocked == true)
        {
            won = true;
            scorehandler.IncrementScore();
            uihandler.WinDisplay();
            //uihandler.DisplayBonusScoreCard(starAnim);
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

    void SelectSpotlight(int pos)
    {
        for (int j = 0; j < spotlight.Length; j++)
        {
            if(j == pos)
            {
                spotlight[j].SetActive(true);
            } else
            {
                spotlight[j].SetActive(false);
            }
        }
    }

    void SelectOF()
    {
        HomelessGirl.color = new Color32(255, 255, 255, 255);
        OFGirl.color = new Color32(126, 126, 126, 255);
        CongressWoman.color = new Color32(126, 126, 126, 255);
        SelectSpotlight(1);
    }

    void SelectHomeless()
    {
        OFGirl.color = new Color32(255, 255, 255, 255);
        HomelessGirl.color = new Color32(126, 126, 126, 255);
        CongressWoman.color = new Color32(126, 126, 126, 255);
        SelectSpotlight(2);
    }

    void SelectCongresswoman()
    {
        OFGirl.color = new Color32(126, 126, 126, 255);
        HomelessGirl.color = new Color32(126, 126, 126, 255);
        CongressWoman.color = new Color32(255, 255, 255, 255);
        SelectSpotlight(0);
    }

    IEnumerator WinOrLose()
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(5));
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        if (won == false)
        {
            characterSelectControls.Disable();
            if (unlocked)
            {
                scorehandler.IncrementScore();
                uihandler.WinDisplay();
                //uihandler.DisplayBonusScoreCard(starAnim);
            }
            else if (moved)
            {
                scorehandler.IncrementScore();
                uihandler.WinDisplay();
            }
            else
            {
                uihandler.LoseDisplay();
            }
        }
    }
}
