using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControls : MonoBehaviour
{
    [SerializeField] MenuController menuController;

    private GameControls characterSelectControls;
    void Awake()
    {
        characterSelectControls = new GameControls();
        characterSelectControls.Select.Choose.performed += x => select();
    }

    private void OnEnable()
    {
        characterSelectControls.Enable();
    }

    private void OnDisable()
    {
        characterSelectControls.Disable();
    }

    private void select()
    {
        menuController.StartGame();
    }
}
