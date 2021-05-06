using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignController : MonoBehaviour
{
    private SignControls signControls;
    Sign[] signs;
    Sign babySign;
    Sign yeahSign;
    // Start is called before the first frame update
    void Awake()
    {
        signControls = new SignControls();
        signs = FindObjectsOfType<Sign>();
        babySign = signs[0];
        yeahSign = signs[1];
    }

    private void OnEnable()
    {
        signControls.Enable();
    }

    private void OnDisable()
    {
        signControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        float movementInput = signControls.Move.Rotate.ReadValue<float>();
        if(movementInput == -1)
        {
            yeahSign.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        } else if (movementInput == 1)
        {
            babySign.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        } else
        {
            yeahSign.transform.eulerAngles = new Vector3(0f, 0f, 80f);
            babySign.transform.eulerAngles = new Vector3(0f, 0f, -80f);
        }
    }
}
