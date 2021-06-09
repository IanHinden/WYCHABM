using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessOrFail : MonoBehaviour
{
    public void WinDisplay()
    {
        GameObject.Find("WinAndLossIcons").transform.GetChild(0).GetComponent<Image>().enabled = true;
    }

    public void LoseDisplay()
    {
        GameObject.Find("WinAndLossIcons").transform.GetChild(1).GetComponent<Image>().enabled = true;
    }
}
