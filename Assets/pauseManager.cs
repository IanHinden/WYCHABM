using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseManager : MonoBehaviour
{
    public AudioSource musicPlayer;
    public GameObject pauseMenu;
    public GameObject pauseButton;
    private bool isPaused = false;

    public void pauseUnpauseGame()
    {
        GameObject titleScreen = GameObject.Find("2. Title Screen");

        if (titleScreen != null)
        {

            if (titleScreen.activeInHierarchy == false)
            {
                //when pause function is called and the menu is still up
                if (isPaused)
                {
                    isPaused = false;
                    musicPlayer.pitch = 1;
                    Time.timeScale = 1;
                    pauseMenu.SetActive(false);
                    pauseButton.SetActive(true);
                }
                //when pause function is called and the menu is hidden
                else if (isPaused == false)
                {
                    isPaused = true;
                    musicPlayer.pitch = 0;
                    Time.timeScale = 0;
                    pauseMenu.SetActive(true);
                    pauseButton.SetActive(false);
                }
            }
        }
        else
        {
            //when pause function is called and the menu is still up
            if (isPaused)
            {
                isPaused = false;
                musicPlayer.pitch = 1;
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                pauseButton.SetActive(true);
            }
            //when pause function is called and the menu is hidden
            else if (isPaused == false)
            {
                isPaused = true;
                musicPlayer.pitch = 0;
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                pauseButton.SetActive(false);
            }
        }
    }

    public void quitGame()
    {

    }

    public void backToMainMenu()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void instructions()
    {

    }
}
