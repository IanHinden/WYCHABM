using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
    ArrayList allscenes = new ArrayList();
    int currentScene = 0;

    [SerializeField] MusicPlayer musicplayer;

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

    [Header("Necesary Functions")]
    [SerializeField] private UIHandler uihandler;
    [SerializeField] private TimeFunctions timefunctions;
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private ScoreHandler scoreHandler;
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
        nextScene();
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(20));
        nextScene();

    }

    private IEnumerator LoseGame()
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(4));

        musicplayer.FadeOutMusic();

        GameObject scoreScreen = (GameObject)allscenes[currentScene + 2];
        GameObject currentActiveScene = (GameObject)allscenes[currentScene];

        currentActiveScene.SetActive(false);
        scoreScreen.SetActive(true);

        currentScene = currentScene + 2;
    }

    private void resetCamera()
    {
        Vector3 targetPosition = new Vector3(0f, 0f, -10f);
        Vector3 threeDCameraPos = new Vector3(-43.8f, 10.59f, -10f);

        Camera camera = maincamera.GetComponent<Camera>();
        Camera threeDcamera = threedcamera.GetComponent<Camera>();

        maincamera.transform.position = targetPosition;
        camera.orthographicSize = 5;

        threeDcamera.transform.position = threeDCameraPos;
    }

    public IEnumerator SwitchScene()
    {
        driveCamRender.enabled = true;
        drivecamera.SetActive(false);
        cityAndBarCo = StartCoroutine(citybehavior.StartAnimations()); //City and Bar Intro
        yield return FadeOutroEffect(20, new Vector2 (450f, 375f), "COLLECT");
        nextScene(8, true, new Vector2(320f, 375f)); //Bar
        fullCoins = StartCoroutine(fullcoins.WinOrLose());


        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        resetCamera();

        nextScene(); //Fired
        yield return FadeOutroEffect(2, new Vector2(635f, 375f), "SIGN");
        nextScene(6, true, new Vector2(699f, 167f)); //Contract
        contractCo = StartCoroutine(contract.WinOrLose());

        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));
        nextScene(); //Landlord
        landlordCo = StartCoroutine(landlord.Dialogue());

        yield return FadeOutroEffect(6, new Vector2(740f, 139f), "SELECT");
        nextScene(6, true, new Vector2(638f, 438f)); //Character Select
        characterSelectCo = StartCoroutine(characterSelector.WinOrLose());

        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));
        nextScene(); // Judgement

        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(2));

        nextScene(); //First Chorus
        firstChorusCo = StartCoroutine(firstChorus.Blink());
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(14));

        nextScene(); //The Family
        yield return FadeOutroEffect(8, new Vector2(740f, 139f), "DON'T");

        nextScene(4, true, new Vector2(699f, 167f)); //Don't Disappoint
        dontDisappointCo = StartCoroutine(disappointer.WinOrLose());
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(4));

        nextScene(); //Absent Dad
        absentDadCo = StartCoroutine(absentDad.Dialogue());
        yield return FadeOutroEffect(6, new Vector2(740f, 139f), "STAB");

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

        yield return FadeOutroEffect(6, new Vector2(740f, 139f), "GET A JOB");

        nextScene(6, true, new Vector2(699f, 167f)); //Job Interview
        jobInterviewCo = StartCoroutine(shuffler.WinOrLose());
        maincamera.SetActive(false);
        threedcamera.SetActive(true);
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));

        nextScene(); //Evolving
        evolvingSC.WinOrLose();
        maincamera.SetActive(true);
        threedcamera.SetActive(false);
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(); //New Mr. Richmond
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(12); //Driving
        drivecamera.SetActive(true);
        maincamera.SetActive(false);
        audioListener.enabled = true;
        roadRacer.Reset();
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(12));

        nextScene(-1); //Cheek to Cheek
        maincamera.SetActive(true);
        drivecamera.SetActive(false);
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(); //See Men
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(4));

        nextScene(); //Second Chorus
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(16));

        nextScene(); //Web Surfing
        yield return FadeOutroEffect(20, new Vector2(740f, 139f), "SPOIL");

        nextScene(4, true, new Vector2(699f, 167f)); //Wishlist
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(4));

        nextScene(); //Online Dating
        yield return FadeOutroEffect(10, new Vector2(740f, 139f), "TWEAK");

        nextScene(6, true, new Vector2(699f, 167f)); //Tweak
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));

        nextScene(); //Party Guy
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));

        nextScene(); //Party Girls
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));

        nextScene(8); //Mensch
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(); //Car Arrival
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(4));

        nextScene(); //Bar View
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(12));
        resetCamera();

        nextScene(); //Make a Deal
        yield return FadeOutroEffect(8, new Vector2(740f, 139f), "MIX");

        nextScene(8, true, new Vector2(699f, 167f)); //Mix
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(); //Bedside
        yield return FadeOutroEffect(4, new Vector2(740f, 139f), "STEALTH");

        nextScene(8, true, new Vector2(699f, 167f)); //Rings
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(); //Sick
        yield return FadeOutroEffect(4, new Vector2(740f, 139f), "AIM");

        nextScene(8, true, new Vector2(699f, 167f)); //Pregnancy Test
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        //Need a fix to destory these
        Droplet[] allDroplets = FindObjectsOfType<Droplet>();
        foreach (Droplet obj in allDroplets)
        {
            Destroy(obj.gameObject);
        }

        nextScene(); //Third Chorus
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(16));

        nextScene(); //Final Boss

        if(scoreHandler.ReturnScore() < 5)
        {
            StartCoroutine(LoseGame());
        } else
        {
            StartCoroutine(WinGame());
        }
    }

    IEnumerator FadeOutroEffect(int measures, Vector2 maskCoordinates, string instruction = null)
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(measures - 2));
        if (instruction != null)
        {
            uihandler.InstructionText(instruction);
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
        if(cityAndBarCo != null) StopCoroutine(cityAndBarCo);
        if(fullCoins != null) StopCoroutine(fullCoins);
        if(contractCo != null) StopCoroutine(contractCo);
        if(landlordCo != null) StopCoroutine(landlordCo);
        if(characterSelectCo != null) StopCoroutine(characterSelectCo);
        if(firstChorusCo != null) StopCoroutine(firstChorusCo);
        if(dontDisappointCo != null) StopCoroutine(dontDisappointCo);
        if(absentDadCo != null) StopCoroutine(absentDadCo);
        if(psychoCo != null) StopCoroutine(psychoCo);
        if(getAJobTimeCo != null) StopCoroutine(getAJobTimeCo);
        if(jobInterviewCo != null) StopCoroutine(jobInterviewCo);

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

        foreach (GameObject scene in allscenes)
        {
            scene.SetActive(false);
        }

        //Reset all UI
        dialogue.QuickExit();
        uihandler.ClearWinLoss();
        uihandler.setFrame(false);
        uihandler.hideSlider();

        TitleScreen.SetActive(true);
        instructions.SetActive(true);
    }
}
