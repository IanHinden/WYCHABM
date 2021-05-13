using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThreeSecondsLeft : MonoBehaviour
{
    private TextMeshProUGUI textmesh;
    // Start is called before the first frame update
    void Start()
    {
        textmesh = GameObject.Find("CountdownImages").transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartCountdown()
    {
        StartCoroutine(TriggerCountdownAnimation());
    }

    IEnumerator TriggerCountdownAnimation()
    {
        textmesh.text = "3";
        yield return new WaitForSeconds(1);
        textmesh.text = "2";
        yield return new WaitForSeconds(1);
        textmesh.text = "1";
        yield return new WaitForSeconds(1);
        textmesh.text = "0";
    }
}
