using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holding : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;
    [SerializeField] TimeFunctions timeFunctions;
    [SerializeField] Dialogue dialogue;
    // Start is called before the first frame update
    void Awake()
    {
        dialogue.QuickExit();
        StartCoroutine(InstructionText());
    }

    IEnumerator InstructionText()
    {
        yield return new WaitForSeconds(timeFunctions.ReturnSingleMeasure());
        uihandler.InstructionText("SIGN");
    }
}
