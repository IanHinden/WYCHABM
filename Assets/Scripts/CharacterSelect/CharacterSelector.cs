using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] ScoreHandler scorehandler;

    [SerializeField] GameObject CongressObjects;
    [SerializeField] GameObject OFObjects;
    [SerializeField] GameObject HomelessObjects;

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

    Animator OFGirlMoves;
    Animator HomelessGirlMoves;
    Animator CongresswomanMoves;

    ParticleSystem CongresswomanParticleSystem;
    ParticleSystem OFParticleSystem;
    ParticleSystem HomelessParticleSystem;
    //Animator starAnim;

    private bool unlocked = false;
    private bool moved = false;
    private bool won = false;

    private int consecutiveLeftClicks = 0;
    private int selectedGirl = 0;

    Character[] characters;
    GameObject[] spotlight = new GameObject[3];
    ParticleSystem[] particles = new ParticleSystem[3];
    private void Awake()
    {
        characterSelectControls = new GameControls();
        characterSelectControls.Select.LeftSelect.performed += x => leftSelect();
        characterSelectControls.Select.RightSelect.performed += x => rightSelect();
        characterSelectControls.Select.Choose.performed += x => StartCoroutine(select());

        characters = FindObjectsOfType<Character>();

        //Sprites
        OFGirl = characters[0].transform.GetChild(0).GetComponent<SpriteRenderer>();
        HomelessGirl = characters[1].transform.GetChild(0).GetComponent<SpriteRenderer>();
        CongressWoman = FindObjectOfType<Congress>().transform.GetChild(0).GetComponent<SpriteRenderer>();

        //Animators
        OFGirlAnim = characters[0].GetComponent<Animator>();
        HomelessGirlAnim = characters[1].GetComponent<Animator>();
        CongressAnim = FindObjectOfType<Congress>().GetComponent<Animator>();

        OFGirlMoves = characters[1].transform.GetChild(0).GetComponent<Animator>();
        HomelessGirlMoves = characters[0].transform.GetChild(0).GetComponent<Animator>();
        CongresswomanMoves = FindObjectOfType<Congress>().transform.GetChild(0).GetComponent<Animator>();

        //Particle Systems
        OFParticleSystem = characters[0].transform.GetChild(3).GetComponent<ParticleSystem>();
        HomelessParticleSystem = characters[1].transform.GetChild(3).GetComponent<ParticleSystem>();
        CongresswomanParticleSystem = FindObjectOfType<Congress>().transform.GetChild(3).GetComponent<ParticleSystem>();

        particles[0] = CongresswomanParticleSystem;
        particles[1] = OFParticleSystem;
        particles[2] = HomelessParticleSystem;

        spotlight[0] = CongressSpotlight;
        spotlight[1] = OFSpotlight;
        spotlight[2] = HomelessSpotlight;

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
        } else
        {
            if(selectedGirl == 1)
            {
                selectedGirl--;
                SelectOF();
            } else if (selectedGirl == 2)
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
            else if (selectedGirl == 2)
            {
                selectedGirl++;
                SelectHomeless();
            }
        }
    }

    IEnumerator select()
    {
        if (moved == true)
        {
            won = true;
            scorehandler.IncrementScore();
            uihandler.WinDisplay();
            characterSelectControls.Disable();
            var emission = particles[selectedGirl].emission;
            emission.enabled = true;
            yield return new WaitForSeconds(.5f);
            emission.rateOverTime = 3;
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
        selectedGirl = 2;
        HomelessGirl.color = new Color32(255, 255, 255, 255);
        OFGirl.color = new Color32(126, 126, 126, 255);
        CongressWoman.color = new Color32(126, 126, 126, 255);
        SelectSpotlight(1);
        StopAllAnimations();
        OFGirlMoves.SetBool("Breathing", true);
    }

    void SelectHomeless()
    {
        selectedGirl = 1;
        OFGirl.color = new Color32(255, 255, 255, 255);
        HomelessGirl.color = new Color32(126, 126, 126, 255);
        CongressWoman.color = new Color32(126, 126, 126, 255);
        SelectSpotlight(2);
        StopAllAnimations();
        HomelessGirlMoves.SetBool("Breathing", true);
    }

    void SelectCongresswoman()
    {
        selectedGirl = 0;
        OFGirl.color = new Color32(126, 126, 126, 255);
        HomelessGirl.color = new Color32(126, 126, 126, 255);
        CongressWoman.color = new Color32(255, 255, 255, 255);
        SelectSpotlight(0);
        StopAllAnimations();
        CongresswomanMoves.SetBool("Breathing", true);
    }

    public IEnumerator WinOrLose()
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

    private void StopAllAnimations()
    {
        if (OFGirlMoves != null && OFGirlMoves.runtimeAnimatorController != null)
        {
            OFGirlMoves.SetBool("Breathing", false);
        }

        if (HomelessGirlMoves != null && HomelessGirlMoves.runtimeAnimatorController != null)
        {
            HomelessGirlMoves.SetBool("Breathing", false);
        }

        if (CongresswomanMoves != null && CongresswomanMoves.runtimeAnimatorController != null)
        {
            CongresswomanMoves.SetBool("Breathing", false);
        }
    }

    private void ResetAllTriggers()
    {
        if (OFGirlAnim != null && OFGirlAnim.runtimeAnimatorController != null)
        {
            OFGirlAnim.ResetTrigger("First");
            OFGirlAnim.ResetTrigger("Second");
        }

        if (HomelessGirlAnim != null && HomelessGirlAnim.runtimeAnimatorController != null)
        {
            HomelessGirlAnim.ResetTrigger("First");
            HomelessGirlAnim.ResetTrigger("Second");
        }

        if (CongressAnim != null && CongressAnim.runtimeAnimatorController != null)
        {
            CongressAnim.ResetTrigger("First");
        }
    }

    private void ResetInitialPositions()
    {
        CongressObjects.transform.position = new Vector3(-16.23f, 0, 0);
        OFObjects.transform.position = new Vector3(0, 0, 0);
        HomelessObjects.transform.position = new Vector3(2.362715f, 0.2504728f, -1133.1f);

        if(HomelessGirl != null) HomelessGirl.color = new Color32(126, 126, 126, 255);
        if(OFGirl != null) OFGirl.color = new Color32(126, 126, 126, 255);
        if(CongressWoman != null) CongressWoman.color = new Color32(126, 126, 126, 255);

        for (int j = 0; j < spotlight.Length; j++)
        {
            if(spotlight[j] != null) spotlight[j].SetActive(false);
        }
    }

    public void Reset()
    {
        selectedGirl = 0;
        won = false;
        moved = false;
        StopAllAnimations();
        ResetAllTriggers();
        ResetInitialPositions();
    }
}
