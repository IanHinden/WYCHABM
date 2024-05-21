using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] MenuControls menuControls;

    [SerializeField] GameObject pressStart;
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject logo;

    [SerializeField] Button startGameButton;
    public List<Button> buttons;
    public List<Button> tutorialButtons;

    [SerializeField] GameObject instructionsMenu2;
    [SerializeField] GameObject instructionsMenu3;
    [SerializeField] GameObject instructionsMenu4;

    [SerializeField] GameObject credits;
    [SerializeField] CreditHolder creditHolder;

    [SerializeField] GameObject menuSoundEffects;
    AudioSource menuSoundEffectsAS;

    private bool playedMenuEffect = false;
    private int currentIndex = 1;

    private void Awake()
    {
        menuSoundEffectsAS = menuSoundEffects.GetComponent<AudioSource>();
        startGameButton.interactable = false;

        StartCoroutine(menuControls.controlPause());

    }
    public void StartGame()
    {
        if (playedMenuEffect == false)
        {
            menuSoundEffectsAS.Play();
            playedMenuEffect = true;
            pressStart.SetActive(false);
            titleScreen.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(buttons[1].gameObject);
            logo.SetActive(true);
            instructionsMenu2.SetActive(false);
            instructionsMenu3.SetActive(false);
        } else
        {
            EventSystem.current.currentSelectedGameObject.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
        }
    }

    public void SetNextActiveButton(int direction)
    {
        int startIndex = currentIndex;
        do
        {
            currentIndex += direction;

            if (currentIndex >= buttons.Count) currentIndex = 0;
            else if (currentIndex < 0) currentIndex = buttons.Count - 1;
            if (currentIndex == startIndex) return;
        } while (!buttons[currentIndex].gameObject.activeInHierarchy || !buttons[currentIndex].interactable);
        if (buttons[currentIndex] != null && buttons[currentIndex].gameObject.activeInHierarchy && buttons[currentIndex].interactable)
        {
            buttons[currentIndex].Select();
        }
    }

    public void switchToCredits()
    {
        titleScreen.SetActive(false);
        logo.SetActive(false);
        credits.SetActive(true);
        creditHolder.ResetPos();
    }

    public void switchToNext2()
    {
        titleScreen.SetActive(false);
        logo.SetActive(false);
        instructionsMenu2.SetActive(true);
        instructionsMenu3.SetActive(false);
        EventSystem.current.SetSelectedGameObject(tutorialButtons[0].gameObject);
    }

    public void switchToNext3()
    {
        instructionsMenu2.SetActive(false);
        instructionsMenu3.SetActive(true);
        instructionsMenu4.SetActive(false);
        EventSystem.current.SetSelectedGameObject(tutorialButtons[2].gameObject);
    }

    public void switchToNext4()
    {
        instructionsMenu3.SetActive(false);
        instructionsMenu4.SetActive(true);
        EventSystem.current.SetSelectedGameObject(tutorialButtons[4].gameObject);
    }

    public void hideInstructions()
    {
        titleScreen.SetActive(true);
        logo.SetActive(true);
        instructionsMenu4.SetActive(false);
        credits.SetActive(false);
        startGameButton.interactable = true;
        EventSystem.current.SetSelectedGameObject(buttons[1].gameObject);
    }
}
