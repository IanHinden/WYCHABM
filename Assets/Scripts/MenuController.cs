using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject pressStart;
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject logo;

    [SerializeField] Button startGameButton;
    public List<Button> buttons;

    [SerializeField] GameObject instructionsMenu2;
    [SerializeField] GameObject instructionsMenu3;
    [SerializeField] GameObject instructionsMenu4;

    [SerializeField] GameObject menuSoundEffects;
    AudioSource menuSoundEffectsAS;

    private bool playedMenuEffect = false;

    private void Awake()
    {
        menuSoundEffectsAS = menuSoundEffects.GetComponent<AudioSource>();
        startGameButton.interactable = false;

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

    public void switchToNext2()
    {
        titleScreen.SetActive(false);
        logo.SetActive(false);
        instructionsMenu2.SetActive(true);
        instructionsMenu3.SetActive(false);
    }

    public void switchToNext3()
    {
        instructionsMenu2.SetActive(false);
        instructionsMenu3.SetActive(true);
        instructionsMenu4.SetActive(false);
    }

    public void switchToNext4()
    {
        instructionsMenu3.SetActive(false);
        instructionsMenu4.SetActive(true);
    }

    public void hideInstructions()
    {
        titleScreen.SetActive(true);
        logo.SetActive(true);
        instructionsMenu4.SetActive(false);
        startGameButton.interactable = true;
    }
}
