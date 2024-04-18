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
        characterSelectControls.Select.DownSelect.performed += x => downSelect();
        characterSelectControls.Select.RightSelect.performed += x => downSelect();
        characterSelectControls.Select.UpSelect.performed += x => upSelect();
        characterSelectControls.Select.LeftSelect.performed += x => upSelect();
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

    private void downSelect()
    {
        menuController.SetNextActiveButton(1);
    }

    private void upSelect()
    {
        menuController.SetNextActiveButton(-1);
    }
}
