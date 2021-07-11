using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    private RichmondLips richmondLips;
    private Spotlight spotlight;
    // Start is called before the first frame update
    void Start()
    {
        richmondLips = FindObjectOfType<RichmondLips>();
        spotlight = FindObjectOfType<Spotlight>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(richmondLips.transform.position.y);
        spotlight.RotateSpotlight();
    }
}
