using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    [SerializeField] UIHandler uiHandler;
    [SerializeField] ScoreHandler scoreHandler;

    private GameControls gamecontrols;

    [SerializeField] GameObject scoreScreen;

    [SerializeField] ScoreStamp scoreStampPart1;
    [SerializeField] ScoreStamp scoreStampPart2;
    [SerializeField] ScoreStamp scoreStampPart3;
    [SerializeField] ScoreStamp scoreStampFinal;

    [SerializeField] GameObject numberPeopleBG;
    [SerializeField] GameObject numberPeopleUnlockedObj;

    [SerializeField] GameObject resetGameButton;
    [SerializeField] GameObject finalThanksButton;
    [SerializeField] GameObject welcomeButton;

    [SerializeField] AudioSource gameOverTheme;

    private void Awake()
    {
        gamecontrols = new GameControls();
        gamecontrols.Move.Select.performed += x => SelectCurrentButton();
        StartCoroutine(ScoreText());
    }

    private void OnEnable()
    {
        gamecontrols.Enable();
    }

    public void OnDisable()
    {
        gamecontrols.Disable();
    }

    public IEnumerator ScoreText()
    {
        yield return new WaitForSeconds(.8f);
        gameOverTheme.Play();
        yield return new WaitForSeconds(1.9f);
        scoreStampPart1.SetGrade(scoreHandler.ReturnPartOneGrade());
        scoreStampPart1.AnimateStamp();
        yield return new WaitForSeconds(.635f);
        scoreStampPart2.SetGrade(scoreHandler.ReturnPartTwoGrade());
        scoreStampPart2.AnimateStamp();
        yield return new WaitForSeconds(.635f);
        scoreStampPart3.SetGrade(scoreHandler.ReturnPartThreeGrade());
        scoreStampPart3.AnimateStamp();

        scoreHandler.AssCheck(scoreHandler.ReturnPartOneGrade(), scoreHandler.ReturnPartTwoGrade(), scoreHandler.ReturnPartThreeGrade());

        yield return new WaitForSeconds(1.27f);
        scoreStampFinal.SetGrade(scoreHandler.ReturnFinalGrade());
        scoreStampFinal.AnimateStamp();
        yield return new WaitForSeconds(2f);
        displayBonusScore();
        resetGameButton.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(resetGameButton);
    }

    private void displayBonusScore()
    {
        numberPeopleBG.SetActive(true);

        BoolArrayWrapper numberPeopleUnlocked = scoreHandler.ReturnBonusesDiscovered();

        for (int i = 0; i < numberPeopleUnlocked.unlockedBonuses.Length; i++)
        {
            if (numberPeopleUnlocked.unlockedBonuses[i])
            {
                numberPeopleUnlockedObj.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        if(scoreHandler.ReturnBonusScore() == 10)
        {
            finalThanksButton.SetActive(true);
        }
    }

    public void Reset()
    {
        scoreStampPart1.ResetStamp();
        scoreStampPart2.ResetStamp();
        scoreStampPart3.ResetStamp();
        scoreStampFinal.ResetStamp();
        numberPeopleBG.SetActive(false);

        for (int i = 0; i < 10; i++)
        {
            numberPeopleUnlockedObj.transform.GetChild(i).gameObject.SetActive(false);
        }

        resetGameButton.SetActive(false);
        finalThanksButton.SetActive(false);
    }

    private void SelectCurrentButton()
    {
        EventSystem.current.currentSelectedGameObject.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
    }

    public void DisableDefaultButtons()
    {
        resetGameButton.SetActive(false);
        finalThanksButton.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(welcomeButton);

    }

    public void EnableDefaultButtons()
    {
        resetGameButton.SetActive(true);
        finalThanksButton.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(finalThanksButton);
    }
}
