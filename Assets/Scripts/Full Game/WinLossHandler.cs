using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLossHandler : MonoBehaviour
{
    [SerializeField] Image winicon;
    [SerializeField] Image loseicon;

    Image greencircle;
    Image redx;

    private void Awake()
    {
        greencircle = winicon.GetComponent<Image>();
        redx = loseicon.GetComponent<Image>();
    }
    public void WinDisplay()
    {
        greencircle.enabled = true;
    }

    public void LoseDisplay()
    {
        redx.enabled = true;
    }

    public void Clear()
    {
        greencircle.enabled = false;
        redx.enabled = false;
    }
}
