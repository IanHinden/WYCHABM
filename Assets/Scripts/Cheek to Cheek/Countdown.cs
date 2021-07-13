using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    private TextMeshProUGUI textmesh;
    void Start()
    {
        textmesh = GetComponent<TextMeshProUGUI>();
        textmesh.text = "TEST";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
