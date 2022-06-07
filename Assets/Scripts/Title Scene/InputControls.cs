using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InputControls : MonoBehaviour
{
    private Controls controls;
    public SceneSwitch sceneSwitch;

    PlayButton[] buttons;

    public int currentlySelect = 0;
    // Start is called before the first frame update
    void Awake()
    {
        controls = new Controls();
        buttons = FindObjectsOfType<PlayButton>();

        controls.Move.Up.performed += x => setPrevious();
        controls.Move.Down.performed += x => setNext();
        controls.Move.Choose.performed += x => properScene();

        setCurrentButton();
    }

    private void setCurrentButton()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i != currentlySelect)
            {
                buttons[i].transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                buttons[i].transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }
    private void setPrevious()
    {
        if (currentlySelect != 0)
        {
            currentlySelect--;
            setCurrentButton();
        }
        else
        {
            currentlySelect = buttons.Length - 1;
            setCurrentButton();
        }
    }

    private void setNext()
    {
        if (currentlySelect != buttons.Length - 1)
        {
            currentlySelect++;
            setCurrentButton();
        }
        else
        {
            currentlySelect = 0;
            setCurrentButton();
        }
    }

    private void properScene()
    {
        if(currentlySelect == 0)
        {
            controls.Disable();
            //sceneSwitch.PlayGame();
            sceneSwitch.LoadNextScene();
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
