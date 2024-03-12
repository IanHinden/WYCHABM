using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBehavior : MonoBehaviour
{
    [SerializeField] TimeFunctions timeFunctions;

    [SerializeField] PartyGuyAnimationController partyGuyAnimationController;

    [SerializeField] GameObject sittingObjects;
    [SerializeField] GameObject avaTexts;

    void Awake()
    {
        StartCoroutine(SceneTiming());
    }

    public IEnumerator SceneTiming()
    {
        yield return null;
        partyGuyAnimationController.SnotBubble();
        yield return new WaitForSeconds(timeFunctions.ReturnCountMeasure(3));
        switchToAva();
        yield return new WaitForSeconds(1f);
        partyGuyAnimationController.sendBP2NiteText();
        yield return new WaitForSeconds(1f);
        partyGuyAnimationController.sendHellYeahText();
        yield return new WaitForSeconds(1f);
        partyGuyAnimationController.setDeliveredText(true);
    }

    private void switchToAva()
    {
        sittingObjects.SetActive(false);
        avaTexts.SetActive(true);
    }

    public void Reset()
    {
        sittingObjects.SetActive(true);
        avaTexts.SetActive(false);
        partyGuyAnimationController.Reset();
    }
}
