using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntireGameControls : MonoBehaviour
{
    [SerializeField] pauseManager pausemanager;
    private GameControls entireGameControls;
    void Awake()
    {
        entireGameControls = new GameControls();
        entireGameControls.Select.Pause.performed += x => pauseUnpause();
        OnDisable();
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
        pausemanager.pauseUnpauseGame();
    }
}
