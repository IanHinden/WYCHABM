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

    [SerializeField] private UIHandler uihandler;
    // Start is called before the first frame update
    //0.705882

    void Awake()
    {
        allscenes.Add(CityAndBarIntro);
        allscenes.Add(BarScene);
        allscenes.Add(Fired);
        allscenes.Add(Contract);
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
        nextScene();
        uihandler.showSlider();
        uihandler.Countdown(8);
        yield return new WaitForSeconds(2.82f);
        yield return new WaitForSeconds(2.82f);
        uihandler.hideSlider();
        nextScene();
        yield return new WaitForSeconds(1.411f);
        nextScene();
        yield return new WaitForSeconds(4.235f);
    }
}
