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

    [SerializeField] GameObject CongressSign;
    [SerializeField] GameObject OFSign;
    [SerializeField] GameObject HomelessSign;

    [SerializeField] GameObject OFSelector;
    [SerializeField] GameObject HomelessSelector;
    [SerializeField] GameObject CongresswomanSelector;

    [SerializeField] GameObject CharacterHighlightSFX;
    private AudioSource CharacterHighlightSFXAS;

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

    SpriteRenderer CongressSignSR;
    SpriteRenderer OFSignSR;
    SpriteRenderer HomelessSignSR;

    SpriteRenderer OFSelectorSR;
    SpriteRenderer HomelessSelectorSR;
    SpriteRenderer CongresswomanSelectorSR;

    ParticleSystem CongresswomanParticleSystem;
    ParticleSystem OFParticleSystem;
    ParticleSystem HomelessParticleSystem;
    //Animator starAnim;

    private bool unlocked = false;
    private bool moved = false;
    private bool won = false;

    private int consecutiveLeftClicks = 0;
    private int selectedGirl = 0;

    private Color selected = new Color32(255, 255, 255, 255);
    private Color deselected = new Color32(126, 126, 126, 255);

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

        OFSelectorSR = OFSelector.GetComponent<SpriteRenderer>();
        HomelessSelectorSR = HomelessSelector.GetComponent<SpriteRenderer>();
        CongresswomanSelectorSR = CongresswomanSelector.GetComponent<SpriteRenderer>();

        //Animators
        OFGirlAnim = characters[0].GetComponent<Animator>();
        HomelessGirlAnim = characters[1].GetComponent<Animator>();
        CongressAnim = FindObjectOfType<Congress>().GetComponent<Animator>();

        OFGirlMoves = characters[1].transform.GetChild(0).GetComponent<Animator>();
        HomelessGirlMoves = characters[0].transform.GetChild(0).GetComponent<Animator>();
        CongresswomanMoves = FindObjectOfType<Congress>().transform.GetChild(0).GetComponent<Animator>();

        //Particle Systems
        OFParticleSystem = characters[0].transform.GetChild(2).GetComponent<ParticleSystem>();
        HomelessParticleSystem = characters[1].transform.GetChild(3).GetComponent<ParticleSystem>();
        CongresswomanParticleSystem = FindObjectOfType<Congress>().transform.GetChild(2).GetComponent<ParticleSystem>();

        particles[0] = CongresswomanParticleSystem;
        particles[1] = OFParticleSystem;
        particles[2] = HomelessParticleSystem;

        spotlight[0] = CongressSpotlight;
        spotlight[1] = OFSpotlight;
        spotlight[2] = HomelessSpotlight;

        CongressSignSR = CongressSign.GetComponent<SpriteRenderer>();
        OFSignSR = OFSign.GetComponent<SpriteRenderer>();
        HomelessSignSR = HomelessSign.GetComponent<SpriteRenderer>();

        CharacterHighlightSFXAS = CharacterHighlightSFX.GetComponent<AudioSource>();

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
            StartCoroutine(Blink(selectedGirl));
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
            scorehandler.IncrementBonusScore(2);
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
        CharacterHighlightSFXAS.Play();
        selectedGirl = 2;
        HomelessGirl.color = selected;
        OFGirl.color = deselected;
        CongressWoman.color = deselected;

        CongressSignSR.color = deselected;
        OFSignSR.color = selected;
        HomelessSignSR.color = deselected;

        OFSelectorSR.enabled = true;
        HomelessSelectorSR.enabled = false;
        CongresswomanSelectorSR.enabled = false;

        SelectSpotlight(1);
        StopAllAnimations();
        OFGirlMoves.SetBool("Breathing", true);
    }

    void SelectHomeless()
    {
        CharacterHighlightSFXAS.Play();
        selectedGirl = 1;
        OFGirl.color = selected;
        HomelessGirl.color = deselected;
        CongressWoman.color = deselected;

        CongressSignSR.color = deselected;
        OFSignSR.color = deselected;
        HomelessSignSR.color = selected;

        OFSelectorSR.enabled = false;
        HomelessSelectorSR.enabled = true;
        CongresswomanSelectorSR.enabled = false;

        SelectSpotlight(2);
        StopAllAnimations();
        HomelessGirlMoves.SetBool("Breathing", true);
    }

    void SelectCongresswoman()
    {
        CharacterHighlightSFXAS.Play();
        selectedGirl = 0;
        OFGirl.color = deselected;
        HomelessGirl.color = deselected;
        CongressWoman.color = selected;

        CongressSignSR.color = selected;
        OFSignSR.color = deselected;
        HomelessSignSR.color = deselected;

        OFSelectorSR.enabled = false;
        HomelessSelectorSR.enabled = false;
        CongresswomanSelectorSR.enabled = true;

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
            uihandler.LoseDisplay();
            SelectHomeless();
        }
    }

    private void StopEmissions()
    {
        if (particles[0] != null)
        {
            for (int i = 0; i < 3; i++)
            {
                var emission = particles[i].emission;
                emission.enabled = false;
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
        if (OFSelectorSR != null)
        {
            CongressObjects.transform.position = new Vector3(-16.23f, 0, 0);
            OFObjects.transform.position = new Vector3(0, 0, 0);
            HomelessObjects.transform.position = new Vector3(2.362715f, 0.2504728f, 0);

            if (HomelessGirl != null) HomelessGirl.color = new Color32(126, 126, 126, 255);
            if (OFGirl != null) OFGirl.color = new Color32(126, 126, 126, 255);
            if (CongressWoman != null) CongressWoman.color = new Color32(126, 126, 126, 255);

            OFSelectorSR.enabled = false;
            HomelessSelectorSR.enabled = false;
            CongresswomanSelectorSR.enabled = false;

            for (int j = 0; j < spotlight.Length; j++)
            {
                if (spotlight[j] != null) spotlight[j].SetActive(false);
            }
        }
    }

    IEnumerator Blink(int selected)
    {
        SpriteRenderer selectedSR = ReturnSelectedSR(selected);

        float blinkTime = (selected == 1 || selected == 2) ? 1.5f : 3f; 
        while (Time.time < blinkTime)
        {
            selectedSR.color = Color.white;
            yield return new WaitForSeconds(.01f);

            selectedSR.color = Color.black;
            yield return new WaitForSeconds(.01f);

            selectedSR.color = Color.white;
            yield return new WaitForSeconds(.01f);
        }
    }

    private SpriteRenderer ReturnSelectedSR(int selected)
    {
        if(selected == 0)
        {
            return CongressWoman;
        } else if (selected == 1)
        {
            return OFGirl;
        } else
        {
            return HomelessGirl;
        }
    }

    public void Reset()
    {
        selectedGirl = 0;
        won = false;
        moved = false;
        StopEmissions();
        StopAllAnimations();
        ResetAllTriggers();
        ResetInitialPositions();
    }
}
