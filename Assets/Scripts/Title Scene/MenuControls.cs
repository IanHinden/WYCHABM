using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControls : MonoBehaviour
{
    [SerializeField] MenuController menuController;

    public float cooldownTime = .005f;
    private float lastClickTime = 0f;

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
        if (Time.time - lastClickTime > cooldownTime)
        {
            menuController.StartGame();
            lastClickTime = Time.time;
        }
    }
}
