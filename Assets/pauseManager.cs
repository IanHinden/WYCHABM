using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using Steamworks;

public class pauseManager : MonoBehaviour
{
    [SerializeField] EntireGameControls entireGameControls;

    [SerializeField] UIHandler uihandler;
    [SerializeField] MenuController menuController;

    public TimeKeeper timekeeper;
    public timingManager timingManager;
    public GameOptions gameoptions;
    public AudioSource musicPlayer;
    public AudioSource themeMusicPlayer;
    public AudioSource endingTheme;
    public MenuSFX menuSFX;
    public GameObject pauseMenu;
    public GameObject pauseButton;
    private bool isPaused = false;

    [SerializeField] GameObject victoryScreen;
    [SerializeField] GameObject scoreScreen;
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject finalBoss;

    public void pauseUnpauseGame()
    {
        //GameObject titleScreen = GameObject.Find("2. Title Screen");
        if (titleScreen != null || victoryScreen != null || scoreScreen!= null || finalBoss != null )
        {

            if (titleScreen.activeInHierarchy == false && victoryScreen.activeInHierarchy == false && scoreScreen.activeInHierarchy == false && finalBoss.activeInHierarchy == false)
            {
                //when pause function is called and the menu is still up
                if (isPaused)
                {
                    //isPaused = false;
                    musicPlayer.pitch = 1;
                    Time.timeScale = 1;
                    pauseMenu.SetActive(false);
                    pauseButton.SetActive(true);
                    StartCoroutine(unPausePause());
                }
                //when pause function is called and the menu is hidden
                else if (isPaused == false)
                {
                    menuSFX.PlayPause();
                    isPaused = true;
                    musicPlayer.pitch = 0;
                    Time.timeScale = 0;
                    pauseMenu.SetActive(true);
                    pauseButton.SetActive(false);
                    entireGameControls.setDefaultButton();
                }
            }
        }
        else
        {
            //when pause function is called and the menu is still up
            if (isPaused)
            {
                //isPaused = false;
                musicPlayer.pitch = 1;
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                pauseButton.SetActive(true);
                StartCoroutine(unPausePause());
            }
            //when pause function is called and the menu is hidden
            else if (isPaused == false)
            {
                menuSFX.PlayPause();
                isPaused = true;
                musicPlayer.pitch = 0;
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                pauseButton.SetActive(false);
                entireGameControls.setDefaultButton();
            }
        }
    }

    private IEnumerator unPausePause()
    {
        yield return new WaitForSeconds(.1f);
        isPaused = false;
    }

    public void quitGame()
    {
        //SteamClient.BShutdownIfAllPipesClosed();
        Application.Quit();
    }

    public void backToMainMenu()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        isPaused = false;
        musicPlayer.pitch = 1;
        musicPlayer.Stop();
        endingTheme.Stop();
        themeMusicPlayer.time = 0;
        themeMusicPlayer.Play();
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        timekeeper.resetGame();
        timingManager.stopTimer();
        uihandler.QuickRemoveScoreCard();
        gameoptions.EndGame();
        menuController.SetStartGameSelected();
        timingManager.resetChorusCount();
    }

    public void instructions()
    {

    }

    public bool IsGamePaused()
    {
        return isPaused;
    }
}
