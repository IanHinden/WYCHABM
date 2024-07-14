using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
    ArrayList allscenes = new ArrayList();
    int currentScene = 0;

    [SerializeField] MusicPlayer musicplayer;
    [SerializeField] VideoController videoController;

    [Header("Cameras")]
    [SerializeField] GameObject maincamera;
    [SerializeField] GameObject threedcamera;
    [SerializeField] GameObject drivecamera;

    [Header("Menus")]
    [SerializeField] GameObject instructions;

    private Camera driveCamRender;
    private AudioListener audioListener;

    [Header("Scenes")]
    [SerializeField] private GameObject TitleScreen;
    [SerializeField] private GameObject CityAndBarIntro;
    [SerializeField] private GameObject BarScene;
    [SerializeField] private GameObject Fired;
    [SerializeField] private GameObject Contract;
    [SerializeField] private GameObject Landlord;
    [SerializeField] private GameObject CharacterSelect;
    [SerializeField] private GameObject Judgement;
    [SerializeField] private GameObject FirstChorus;
    [SerializeField] private GameObject TheFamily;
    [SerializeField] private GameObject DontDisappoint;
    [SerializeField] private GameObject AbsentDad;
    [SerializeField] private GameObject Psycho;
    [SerializeField] private GameObject GetAJob;
    [SerializeField] private GameObject JobInterview;
    [SerializeField] private GameObject Evolving;
    [SerializeField] private GameObject NewMrRichmond;
    [SerializeField] private GameObject Driving;
    [SerializeField] private GameObject CheekToCheek;
    [SerializeField] private GameObject SeeMen;
    [SerializeField] private GameObject SecondChorus;
    [SerializeField] private GameObject WebSurfing;
    [SerializeField] private GameObject Wishlist;
    [SerializeField] private GameObject OnlineDating;
    [SerializeField] private GameObject Tweak;
    [SerializeField] private GameObject PartyGuy;
    [SerializeField] private GameObject PartyGirls;
    [SerializeField] private GameObject Mensch;
    [SerializeField] private GameObject CarArrival;
    [SerializeField] private GameObject BarView;
    [SerializeField] private GameObject MakeADeal;
    [SerializeField] private GameObject Mix;
    [SerializeField] private GameObject Bedside;
    [SerializeField] private GameObject Rings;
    [SerializeField] private GameObject Sick;
    [SerializeField] private GameObject PregnancyTest;
    [SerializeField] private GameObject ThirdChorus;
    [SerializeField] private GameObject FinalBoss;
    [SerializeField] private GameObject VictoryScreen;
    [SerializeField] private GameObject ScoreScreen;

    [Header("Reset Scripts")]
    [SerializeField] CityBehavior citybehavior; //Scene 3
    [SerializeField] FullCoins fullcoins; //Scene 4
    [SerializeField] Contract contract; //Scene 6
    [SerializeField] Landlord landlord; //Scene 7
    [SerializeField] CharacterSelector characterSelector; //Scene 8
    [SerializeField] FirstChorus firstChorus; //Scene 10
    [SerializeField] Disappointer disappointer; //Scene 12
    [SerializeField] AbsentDad absentDad; //Scene 13
    [SerializeField] StabCheck stabCheck; //Scene 14
    [SerializeField] GetAJobTime getAJobTime; //Scene 15
    [SerializeField] Shuffler shuffler; //Scene 16
    [SerializeField] EvolvingSceneController evolvingSC; //Scene 17
    [SerializeField] RoadRacer roadRacer; //Scene 19
    [SerializeField] DriveWinLoseLogic driveWinLoseLogic; //Scene 19
    [SerializeField] Gameplay cheekToCheek; //Scene 20
    [SerializeField] SeeMenTiming seeMenTiming; //Scene 21
    [SerializeField] SecondChorus secondChorus; //Scene 22
    [SerializeField] StoryTimer webSurfing; //Scene 23
    [SerializeField] SelectChecker selectChecker; //Scene 24
    [SerializeField] StoryTimerOD onlineDating; //Scene 25
    [SerializeField] TweakGameplay tweakGameplay; //Scene 26
    [SerializeField] SceneBehavior partyGuy; //Scene 27
    [SerializeField] StoryTimerPG storyTimerPG;
    [SerializeField] MenschGameplay menschGameplay; //Scene 29
    [SerializeField] Avas avas; //Scene 30
    [SerializeField] Timing barView; // Scene 31
    [SerializeField] MADAnimationController madAnimationController; // Scene 32
    [SerializeField] Straw mixGameplay; //Scene 33
    [SerializeField] RingsGameplay ringsGameplay; //Scene 35
    [SerializeField] Target pregnancyTest; //Scene 37
    [SerializeField] ThirdChorus thirdChorus; //Scene 38
    [SerializeField] FinalBossAnimationController finalBossAnim; // Scene 39
    [SerializeField] FinalScore finalScore; //Scene 41
    //30, 35, 37. 


    [Header("Necesary Functions")]
    [SerializeField] private UIHandler uihandler;
    [SerializeField] private TimeFunctions timefunctions;
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private ScoreHandler scoreHandler;

    [SerializeField] FinalBossSFXController finalBossSFXController;
    // Start is called before the first frame update
    //0.705882

    Coroutine cityAndBarCo;
    Coroutine fullCoins;
    Coroutine landlordCo;
    Coroutine contractCo;
    Coroutine characterSelectCo;
    Coroutine firstChorusCo;
    Coroutine dontDisappointCo;
    Coroutine absentDadCo;
    Coroutine getAJobTimeCo;
    Coroutine psychoCo;
    Coroutine jobInterviewCo;
    Coroutine driveWinLoseLogicCo;
    Coroutine cheekToCheekCo;
    Coroutine seeMenCo;
    Coroutine secondChorusCo;
    Coroutine webSurfingCo;
    Coroutine wishlistCo;
    Coroutine onlineDatingCo;
    Coroutine partyGuyCo;
    Coroutine storyTimerPGCo;
    Coroutine tweakCo;
    Coroutine menschCo;
    Coroutine avasCo;
    Coroutine barViewCo;
    Coroutine makeADealCo;
    Coroutine mixGameplayCo;
    Coroutine ringsCo;
    Coroutine pregnancyTestCo;
    Coroutine thirdChorusCo;
    Coroutine finalBossCo;
    Coroutine FinalScoreCo;

    Coroutine WinOrLoseGameCo;
    void Awake()
    {
        driveCamRender = drivecamera.transform.GetChild(0).GetComponent<Camera>();
        audioListener = drivecamera.GetComponent<AudioListener>();

        allscenes.Add(CityAndBarIntro);
        allscenes.Add(BarScene);
        allscenes.Add(Fired);
        allscenes.Add(Contract);
        allscenes.Add(Landlord);
        allscenes.Add(CharacterSelect);
        allscenes.Add(Judgement);
        allscenes.Add(FirstChorus);
        allscenes.Add(TheFamily);
        allscenes.Add(DontDisappoint);
        allscenes.Add(AbsentDad);
        allscenes.Add(Psycho);
        allscenes.Add(GetAJob);
        allscenes.Add(JobInterview);
        allscenes.Add(Evolving);
        allscenes.Add(NewMrRichmond);
        allscenes.Add(Driving);
        allscenes.Add(CheekToCheek);
        allscenes.Add(SeeMen);
        allscenes.Add(SecondChorus);
        allscenes.Add(WebSurfing);
        allscenes.Add(Wishlist);
        allscenes.Add(OnlineDating);
        allscenes.Add(Tweak);
        allscenes.Add(PartyGuy);
        allscenes.Add(PartyGirls);
        allscenes.Add(Mensch);
        allscenes.Add(CarArrival);
        allscenes.Add(BarView);
        allscenes.Add(MakeADeal);
        allscenes.Add(Mix);
        allscenes.Add(Bedside);
        allscenes.Add(Rings);
        allscenes.Add(Sick);
        allscenes.Add(PregnancyTest);
        allscenes.Add(ThirdChorus);
        allscenes.Add(FinalBoss);
        allscenes.Add(VictoryScreen); //37
        allscenes.Add(ScoreScreen); //38
    }

    private void nextScene(int countdown = 0, bool outro = false, Vector2 maskCoordinates = default(Vector2))
    {
        if (outro)
        {
            //uihandler.MaskIntro(maskCoordinates);
        }

        uihandler.ClearWinLoss();
        dialogue.QuickExit();

        if(countdown > 0)
        {
            uihandler.setFrame(true);
            uihandler.showSlider();
            uihandler.Countdown(countdown);
        } else if(countdown == 0)
        {
            uihandler.setFrame(false);
            uihandler.hideSlider();
        } else
        {
            uihandler.setFrame(true);
            uihandler.showSlider();
            uihandler.CountdownCheek();
        }

        GameObject nextActiveScene = (GameObject)allscenes[currentScene + 1];
        GameObject currentActiveScene = (GameObject)allscenes[currentScene];

        currentActiveScene.SetActive(false);
        nextActiveScene.SetActive(true);

        currentScene++;
    }

    private IEnumerator WinGame()
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(35));

        nextScene();
        videoController.PlayVideo();

        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(30));

        StartCoroutine(musicplayer.FadeOutMusic());
        GameObject scoreScreen = (GameObject)allscenes[currentScene + 1];
        GameObject currentActiveScene = (GameObject)allscenes[currentScene];

        currentActiveScene.SetActive(false);
        FinalScoreCo = StartCoroutine(finalScore.ScoreText());
        scoreScreen.SetActive(true);

        currentScene = currentScene + 1;
    }

    private IEnumerator LoseGame()
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(35));

        StartCoroutine(musicplayer.FadeOutMusic());

        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(1));

        GameObject scoreScreen = (GameObject)allscenes[currentScene + 2];
        GameObject currentActiveScene = (GameObject)allscenes[currentScene];

        StartCoroutine(uihandler.BlackOutTwoFadeIn());
        yield return new WaitForSeconds(.5f);
        finalBossSFXController.PlayRichmanLaugh();
        yield return new WaitForSeconds(1.5f);
        uihandler.TurnOffBlackout();
        currentActiveScene.SetActive(false);
        FinalScoreCo = StartCoroutine(finalScore.ScoreText());
        scoreScreen.SetActive(true);

        currentScene = currentScene + 2;
    }

    public void resetCamera()
    {
        Vector3 targetPosition = new Vector3(0f, 0f, -10f);
        Vector3 threeDCameraPos = new Vector3(-43.8f, 10.59f, -10f);

        Camera camera = maincamera.GetComponent<Camera>();
        Camera threeDcamera = threedcamera.GetComponent<Camera>();

        maincamera.transform.position = targetPosition;
        camera.orthographicSize = 5;

        threeDcamera.transform.position = threeDCameraPos;

        driveCamRender.enabled = true;
        drivecamera.SetActive(false);
        maincamera.SetActive(true);
        threedcamera.SetActive(false);
    }

    public IEnumerator SwitchScene()
    {
        driveCamRender.enabled = true;
        drivecamera.SetActive(false);
        cityAndBarCo = StartCoroutine(citybehavior.StartAnimations()); //City and Bar Intro
        yield return FadeOutroEffect(20, new Vector2 (450f, 375f), "COLLECT", 0);
        nextScene(8, true, new Vector2(320f, 375f)); //Bar
        fullCoins = StartCoroutine(fullcoins.WinOrLose());


        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        resetCamera();

        nextScene(); //Fired
        yield return FadeOutroEffect(3, new Vector2(635f, 375f), "SIGN", 1);
        nextScene(5, true, new Vector2(699f, 167f)); //Contract
        contractCo = StartCoroutine(contract.WinOrLose());

        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(5));
        nextScene(); //Landlord
        landlordCo = StartCoroutine(landlord.Dialogue());

        yield return FadeOutroEffect(6, new Vector2(740f, 139f), "SELECT", 2);
        nextScene(6, true, new Vector2(638f, 438f)); //Character Select
        characterSelectCo = StartCoroutine(characterSelector.WinOrLose());

        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));
        nextScene(); // Judgement

        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(2));

        nextScene(); //First Chorus
        firstChorusCo = StartCoroutine(firstChorus.Blink());
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(14));

        uihandler.ClearRhythmRating();
        nextScene(); //The Family
        yield return FadeOutroEffect(8, new Vector2(740f, 139f), "DON'T", 3);

        nextScene(4, true, new Vector2(699f, 167f)); //Don't Disappoint
        dontDisappointCo = StartCoroutine(disappointer.WinOrLose());
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(4));

        nextScene(); //Absent Dad
        absentDadCo = StartCoroutine(absentDad.Dialogue());
        yield return FadeOutroEffect(6, new Vector2(740f, 139f), "STAB", 4);

        nextScene(6, true, new Vector2(699f, 167f)); //Psycho
        psychoCo = StartCoroutine(stabCheck.WinOrLose());
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));

        nextScene(); //Get a Job
        getAJobTimeCo = StartCoroutine(getAJobTime.AllEvents());
        Stabhole[] allStabhole = FindObjectsOfType<Stabhole>();
        foreach (Stabhole obj in allStabhole)
        {
            Destroy(obj.gameObject);
        }

        yield return FadeOutroEffect(6, new Vector2(740f, 139f), "GET A JOB", 5);

        nextScene(7, true, new Vector2(699f, 167f)); //Job Interview
        jobInterviewCo = StartCoroutine(shuffler.WinOrLose());
        maincamera.SetActive(false);
        threedcamera.SetActive(true);
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(7));

        nextScene(); //Evolving
        evolvingSC.WinOrLose();
        maincamera.SetActive(true);
        threedcamera.SetActive(false);
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(7));

        nextScene(); //New Mr. Richmond
        yield return FadeOutroEffect(8, new Vector2(740f, 139f), "DRIVE", 6);

        nextScene(12); //Driving
        drivecamera.SetActive(true);
        maincamera.SetActive(false);
        audioListener.enabled = true;
        driveWinLoseLogicCo = StartCoroutine(driveWinLoseLogic.WinOrLose());
        roadRacer.Reset();
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(12));

        nextScene(-1); //Cheek to Cheek
        cheekToCheekCo = StartCoroutine(cheekToCheek.GameSwitcher());
        maincamera.SetActive(true);
        drivecamera.SetActive(false);
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(); //See Men
        seeMenCo = StartCoroutine(seeMenTiming.Dance());
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(4));

        nextScene(); //Second Chorus
        secondChorusCo = StartCoroutine(secondChorus.Blink());
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(16));

        //Web surfing 20 - 8 = 12; 4 wishlist, 2 Tweak, 4 more Party Guy
        uihandler.ClearRhythmRating();
        nextScene(); //Web Surfing
        webSurfingCo = StartCoroutine(webSurfing.timedEvents());
        yield return FadeOutroEffect(8, new Vector2(740f, 139f), "SPOIL", 9);

        nextScene(8, true, new Vector2(699f, 167f)); //Wishlist
        wishlistCo = StartCoroutine(selectChecker.WinOrLose());
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(); //Online Dating
        onlineDatingCo = StartCoroutine(onlineDating.SceneTiming());
        onlineDatingCo = StartCoroutine(onlineDating.SceneTiming());
        yield return FadeOutroEffect(8, new Vector2(740f, 139f), "TWEAK", 10);

        nextScene(8, true, new Vector2(699f, 167f)); //Tweak
        tweakCo = StartCoroutine(tweakGameplay.WinOrLose());
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(); //Party Guy
        partyGuyCo = StartCoroutine(partyGuy.SceneTiming());
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(10));

        nextScene(); //Party Girls
        storyTimerPGCo = StartCoroutine(storyTimerPG.timedEvents());
        yield return FadeOutroEffect(6, new Vector2(699f, 167f), "SHARE", 11); //timefunctions.ReturnCountMeasure(6));

        nextScene(8); //Mensch
        menschCo = StartCoroutine(menschGameplay.WinOrLose());
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(); //Car Arrival
        avasCo = StartCoroutine(avas.Sway());
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(4));

        nextScene(); //Bar View
        barViewCo = StartCoroutine(barView.WaitressMove());
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(16));
        resetCamera();

        nextScene(); //Make a Deal
        makeADealCo = StartCoroutine(madAnimationController.Dialogue());
        yield return FadeOutroEffect(8, new Vector2(740f, 139f), "MIX", 12);

        nextScene(8, true, new Vector2(699f, 167f)); //Mix
        mixGameplayCo = StartCoroutine(mixGameplay.WinOrLose());
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(); //Bedside
        yield return FadeOutroEffect(4, new Vector2(740f, 139f), "STEALTH", 13);

        nextScene(8, true, new Vector2(699f, 167f)); //Rings
        ringsCo = StartCoroutine(ringsGameplay.WinOrLose());
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(); //Sick
        yield return FadeOutroEffect(4, new Vector2(740f, 139f), "AIM", 14);

        nextScene(8, true, new Vector2(699f, 167f)); //Pregnancy Test
        pregnancyTestCo = StartCoroutine(pregnancyTest.WinOrLose());
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        //Need a fix to destory these
        Droplet[] allDroplets = FindObjectsOfType<Droplet>();
        foreach (Droplet obj in allDroplets)
        {
            Destroy(obj.gameObject);
        }

        nextScene(); //Third Chorus
        thirdChorusCo = StartCoroutine(thirdChorus.Blink());
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(16));

        uihandler.ClearRhythmRating();
        nextScene(); //Final Boss
        finalBossCo = StartCoroutine(finalBossAnim.SceneTiming());

        string finalGrade = scoreHandler.ReturnFinalGrade();

        if(finalGrade == "A" || finalGrade == "B" || finalGrade == "S")
        {
            WinOrLoseGameCo = StartCoroutine(WinGame());
        } else
        {
            WinOrLoseGameCo = StartCoroutine(LoseGame());
        }
    }

    IEnumerator FadeOutroEffect(int measures, Vector2 maskCoordinates, string instruction = null, int instructionSFX = 0)
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(measures - 2));
        if (instruction != null)
        {
            uihandler.InstructionText(instruction, instructionSFX);
        }
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(2) - .8f);
 
        //uihandler.MaskOutro(maskCoordinates);
        yield return new WaitForSeconds(.8f);
    }

    public void resetGame()
    {
        resetCamera();
        currentScene = 0;
        scoreHandler.ResetScore();
        if (cityAndBarCo != null) StopCoroutine(cityAndBarCo);
        if (fullCoins != null) StopCoroutine(fullCoins);
        if (contractCo != null) StopCoroutine(contractCo);
        if (landlordCo != null) StopCoroutine(landlordCo);
        if (characterSelectCo != null) StopCoroutine(characterSelectCo);
        if (firstChorusCo != null) StopCoroutine(firstChorusCo);
        if (dontDisappointCo != null) StopCoroutine(dontDisappointCo);
        if (absentDadCo != null) StopCoroutine(absentDadCo);
        if (psychoCo != null) StopCoroutine(psychoCo);
        if (getAJobTimeCo != null) StopCoroutine(getAJobTimeCo);
        if (jobInterviewCo != null) StopCoroutine(jobInterviewCo);
        if (driveWinLoseLogicCo != null) StopCoroutine(driveWinLoseLogicCo);
        if (cheekToCheekCo != null) StopCoroutine(cheekToCheekCo);
        if (seeMenCo != null) StopCoroutine(seeMenCo);
        if (secondChorusCo != null) StopCoroutine(secondChorusCo);
        if (webSurfingCo != null) StopCoroutine(webSurfingCo);
        if (wishlistCo != null) StopCoroutine(wishlistCo);
        if (onlineDatingCo != null) StopCoroutine(onlineDatingCo);
        if (tweakCo != null) StopCoroutine(tweakCo);
        if (partyGuyCo != null) StopCoroutine(partyGuyCo);
        if (storyTimerPGCo != null) StopCoroutine(storyTimerPGCo);
        if (menschCo != null) StopCoroutine(menschCo);
        if (avasCo != null) StopCoroutine(avasCo);
        if (barViewCo != null) StopCoroutine(barViewCo);
        if (makeADealCo != null) StopCoroutine(makeADealCo);
        if (mixGameplayCo != null) StopCoroutine(mixGameplayCo);
        if (ringsCo != null) StopCoroutine(ringsCo);
        if (pregnancyTestCo != null) StopCoroutine(pregnancyTestCo);
        if (thirdChorusCo != null) StopCoroutine(thirdChorusCo);
        if (finalBossCo != null) StopCoroutine(finalBossCo);
        if (FinalScoreCo != null) StopCoroutine(FinalScoreCo);

        if (WinOrLoseGameCo != null) StopCoroutine(WinOrLoseGameCo);

        citybehavior.Reset();
        fullcoins.Reset();
        contract.Reset();
        landlord.Reset();
        characterSelector.Reset();
        firstChorus.Reset();
        disappointer.Reset();
        stabCheck.Reset();
        getAJobTime.Reset();
        shuffler.Reset();
        evolvingSC.Reset();
        cheekToCheek.Reset();
        seeMenTiming.Reset();
        secondChorus.Reset();
        webSurfing.Reset();
        selectChecker.Reset();
        onlineDating.Reset();
        tweakGameplay.Reset();
        partyGuy.Reset();
        storyTimerPG.Reset();
        menschGameplay.Reset();
        avas.Reset();
        barView.Reset();
        mixGameplay.Reset();
        ringsGameplay.Reset();
        pregnancyTest.Reset();
        thirdChorus.Reset();
        finalBossAnim.Reset();
        finalScore.Reset();

        foreach (GameObject scene in allscenes)
        {
            scene.SetActive(false);
        }

        //Reset all UI
        dialogue.Reset();
        uihandler.Reset();

        TitleScreen.SetActive(true);
        instructions.SetActive(true);
    }
}
