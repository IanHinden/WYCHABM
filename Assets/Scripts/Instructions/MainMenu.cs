using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneSwitch sceneSwitch;
    public void PlayGame()
    {
        sceneSwitch.PlayGame();
        sceneSwitch.LoadNextScene();
    }
}
