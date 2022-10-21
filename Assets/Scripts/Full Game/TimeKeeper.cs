﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
    ArrayList allscenes = new ArrayList();
    int currentScene = 0;

    [SerializeField] Camera maincamera;

    [Header("Scenes")]
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
    [SerializeField] private GameObject ScoreScreen;

    [Header("Necesary Functions")]
    [SerializeField] private UIHandler uihandler;
    [SerializeField] private TimeFunctions timefunctions;
    // Start is called before the first frame update
    //0.705882

    void Awake()
    {
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
        allscenes.Add(ScoreScreen);

        StartCoroutine(SwitchScene());
    }

    private void nextScene(int countdown = 0)
    {
        uihandler.ClearWinLoss();

        if(countdown != 0)
        {
            uihandler.showSlider();
            uihandler.Countdown(countdown);
        } else
        {
            uihandler.hideSlider();
        }

        GameObject nextActiveScene = (GameObject)allscenes[currentScene + 1];
        GameObject currentActiveScene = (GameObject)allscenes[currentScene];

        currentActiveScene.SetActive(false);
        nextActiveScene.SetActive(true);

        currentScene++;
    }

    private void resetCamera()
    {
        Vector3 targetPosition = new Vector3(0f, 0f, -10f);

        maincamera.transform.position = targetPosition;
    }

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(20));
        nextScene(8); //Bar
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));
        uihandler.hideSlider();

        resetCamera();

        nextScene(); //Fired
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(2));
        nextScene(6); //Contract
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));
        uihandler.hideSlider();
        nextScene(); //Landlord
        
        //Need a fix to destory these
        Ink[] allInk = FindObjectsOfType<Ink>();
        foreach (Ink obj in allInk)
        {
            obj.GetComponent<SpriteRenderer>().enabled = false;
        }

        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));
        nextScene(6); // Character Select
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));
        nextScene(); // Judgement
        uihandler.hideSlider();

        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(2));

        nextScene(); //First Chorus
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(14));

        nextScene(); //The Family
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(4); //Don't Disappoint
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(4));

        nextScene(); //Absent Dad
        uihandler.hideSlider();
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));

        nextScene(6); //Psycho
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));

        nextScene(); //Get a Job
        uihandler.hideSlider();
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));

        nextScene(6); //Job Interview
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));

        nextScene(); //Evolving
        uihandler.hideSlider();
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(); //New Mr. Richmond
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(12); //Driving
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(12));

        nextScene(); //Cheek to Cheek
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(); //See Men
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(4));

        nextScene(); //Second Chorus
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(16));

        nextScene(); //Web Surfing
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(20));

        nextScene(4); //Wishlist
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(4));

        nextScene(); //Online Dating
        uihandler.hideSlider();
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(10));

        nextScene(6); //Tweak
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));

        nextScene(); //Party Guy
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(5));

        nextScene(); //Party Girls
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));

        nextScene(8); //Mensch
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(); //Car Arrival
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(4));

        nextScene(); //Bar View
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(12));

        nextScene(); //Make a Wish
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(8); //Mix
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(); //Bedside
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(4));

        nextScene(8); //Rings
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(); //Sick
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(4));

        nextScene(8); //Pregnancy Test
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(); //Third Chorus
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(16));

        nextScene(); //Final Boss
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(20));
    }
}
