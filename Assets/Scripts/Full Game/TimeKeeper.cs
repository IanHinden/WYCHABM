using System.Collections;
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

        StartCoroutine(SwitchScene());
    }

    private void nextScene()
    {
        uihandler.ClearWinLoss();

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
        nextScene(); //Bar
        uihandler.showSlider();
        uihandler.Countdown(8);
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));
        uihandler.hideSlider();

        resetCamera();

        nextScene(); //Fired
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(2));
        nextScene(); //Contract
        uihandler.showSlider();
        uihandler.Countdown(6);
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));
        uihandler.hideSlider();
        nextScene(); //Landlord
        
        //Need a fix to destory these
        Ink[] allInk = FindObjectsOfType<Ink>();
        foreach (Ink obj in allInk)
        {
            obj.GetComponent<SpriteRenderer>().enabled = false;
        }

        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(5));
        nextScene(); // Character Select
        uihandler.showSlider();
        uihandler.Countdown(6);
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));
        nextScene(); // Judgement
        uihandler.hideSlider();

        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(2));

        nextScene(); //First Chorus
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(14));

        nextScene(); //The Family
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(); //Don't Disappoint
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(4));

        nextScene(); //Absent Dad
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));

        nextScene(); //Psycho
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));

        nextScene(); //Get a Job
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));

        nextScene(); //Job Interview
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(6));

        nextScene(); //Evolving
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(); //New Mr. Richmond
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(8));

        nextScene(); //Driving
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(12));
    }
}
