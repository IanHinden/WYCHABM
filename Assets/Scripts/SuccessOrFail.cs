using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessOrFail : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void WinDisplay()
    {
        GameObject.Find("WinAndLossIcons").transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
    }

    public void LoseDisplay()
    {
        GameObject.Find("WinAndLossIcons").transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
