using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
    ArrayList allscenes = new ArrayList();
    int currentScene = 0;

    [SerializeField] private GameObject CityAndBarIntro;
    [SerializeField] private GameObject BarScene;
    [SerializeField] private GameObject Fired;
    [SerializeField] private GameObject Contract;
    [SerializeField] private GameObject Landlord;
    [SerializeField] private GameObject CharacterSelect;

    [SerializeField] private UIHandler uihandler;
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

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(14.1176f);
        nextScene(); //Bar
        uihandler.showSlider();
        uihandler.Countdown(8);
        yield return new WaitForSeconds(2.82f);
        yield return new WaitForSeconds(2.82f);
        uihandler.hideSlider();
        nextScene(); //Fired
        yield return new WaitForSeconds(1.411f);
        nextScene(); //Contract
        uihandler.showSlider();
        uihandler.Countdown(6);
        yield return new WaitForSeconds(4.235f);
        uihandler.hideSlider();
        nextScene(); //Landlord
        
        //Need a fix to destory these
        Ink[] allInk = FindObjectsOfType<Ink>();
        foreach (Ink obj in allInk)
        {
            obj.GetComponent<SpriteRenderer>().enabled = false;
        }

        yield return new WaitForSeconds(4.235f);
        nextScene(); // Character Select
        uihandler.showSlider();
        uihandler.Countdown(6);
        yield return new WaitForSeconds(4.235f);
        nextScene();
        uihandler.hideSlider();
    }
}
