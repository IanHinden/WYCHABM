using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessOrFail : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Test");
    }

    public void WinDisplay()
    {
        GameObject.Find("WinAndLossIcons").transform.GetChild(0).GetComponent<Image>().enabled = true;
    }

    public void LoseDisplay()
    {
        GameObject.Find("WinAndLossIcons").transform.GetChild(1).GetComponent<Image>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
