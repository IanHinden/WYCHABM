using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject pressStart;
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject instructionsMenu2;
    [SerializeField] GameObject instructionsMenu3;

    public void StartGame()
    {
        pressStart.SetActive(false);
        titleScreen.SetActive(true);
        instructionsMenu2.SetActive(false);
        instructionsMenu3.SetActive(false);
    }

    public void switchToNext2()
    {
        titleScreen.SetActive(false);
        instructionsMenu2.SetActive(true);
    }

    public void switchToNext3()
    {
        instructionsMenu2.SetActive(false);
        instructionsMenu3.SetActive(true);
    }
}
