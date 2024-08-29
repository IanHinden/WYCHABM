using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class EntireGameControls : MonoBehaviour
{
    [SerializeField] pauseManager pausemanager;
    [SerializeField] UIHandler uiHandler;

    public List<Button> pauseButtons;

    private GameControls entireGameControls;

    private int currentIndex = 0;
    private bool paused = false;
    private bool pauseHidden = false;
    private void Awake()
    {
        entireGameControls = new GameControls();
        entireGameControls.Select.Pause.performed += x => pauseUnpause();
        entireGameControls.Select.Choose.performed += x => selectCurrentButton();
        entireGameControls.Select.DownSelect.performed += x => downSelect();
        entireGameControls.Select.RightSelect.performed += x => downSelect();
        entireGameControls.Select.UpSelect.performed += x => upSelect();
        entireGameControls.Select.LeftSelect.performed += x => upSelect();
        entireGameControls.Select.FullScreenToggle.performed += x => fullScreenToggle();
        entireGameControls.Select.PauseToggle.performed += x => pauseScreenToggle();
        //OnDisable();
    }

    private void OnEnable()
    {
        entireGameControls.Enable();
    }

    private void OnDisable()
    {
        entireGameControls.Disable();
    }

    private void pauseUnpause()
    {
        paused = !paused;
        pausemanager.pauseUnpauseGame();
        if(paused == false)
        {
            pauseHidden = false;
        }
    }

    public void SetNextActiveButton(int direction)
    {
        int startIndex = currentIndex;
        do
        {
            currentIndex += direction;

            if (currentIndex >= pauseButtons.Count) currentIndex = 0;
            else if (currentIndex < 0) currentIndex = pauseButtons.Count - 1;
            if (currentIndex == startIndex) return;
        } while (!pauseButtons[currentIndex].gameObject.activeInHierarchy || !pauseButtons[currentIndex].interactable);
        if (pauseButtons[currentIndex] != null && pauseButtons[currentIndex].gameObject.activeInHierarchy && pauseButtons[currentIndex].interactable)
        {
            pauseButtons[currentIndex].Select();
        }
    }

    private void downSelect()
    {
        if (paused == true)
        {
            SetNextActiveButton(1);
        }
    }

    private void upSelect()
    {
        if (paused == true)
        {
            SetNextActiveButton(-1);
        }
    }

    private void pauseScreenToggle()
    {
        if (paused == true)
        {
            pauseHidden = !pauseHidden;
            uiHandler.PauseScreenVisible(!pauseHidden);
        }
    }

    public void setDefaultButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseButtons[0].gameObject);
        pauseButtons[0].Select();
        currentIndex = 0;
    }

    private void selectCurrentButton()
    {
        if (paused == true)
        {
            EventSystem.current.currentSelectedGameObject.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
            paused = false;
        }
    }

    private void fullScreenToggle()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
