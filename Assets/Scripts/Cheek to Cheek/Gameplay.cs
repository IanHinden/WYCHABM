using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    private RichmondLips richmondLips;
    private Spotlight spotlight;
    private KissHit kissHit;
    // Start is called before the first frame update
    void Awake()
    {
        richmondLips = FindObjectOfType<RichmondLips>();
        spotlight = FindObjectOfType<Spotlight>();

        kissHit = new KissHit();
        kissHit.Action.Select.performed += x => GameAction();
    }


    private void OnEnable()
    {
        kissHit.Enable();
    }

    private void OnDisable()
    {
        kissHit.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(richmondLips.transform.position.y);
        spotlight.RotateSpotlight();
    }

    private void GameAction()
    {
        Debug.Log("Game action");
    }
}
