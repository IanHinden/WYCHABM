using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsAnimationController : MonoBehaviour
{
    [SerializeField] GameObject SpaceUp;
    [SerializeField] GameObject SpaceDown;

    private float timePassed = 0f;

    void Awake()
    {
        SpaceUp.SetActive(true);
        SpaceDown.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timePassed += Time.deltaTime;

        if(timePassed > 1f && timePassed < 2f)
        {
            SpaceUp.SetActive(false);
            SpaceDown.SetActive(true);
        }

        if (timePassed > 2f && timePassed < 3f)
        {
            SpaceUp.SetActive(true);
            SpaceDown.SetActive(false);
        }

        if (timePassed > 3f && timePassed < 4f)
        {
            SpaceUp.SetActive(false);
            SpaceDown.SetActive(true);
        }

        if (timePassed > 4f && timePassed < 5f)
        {
            SpaceUp.SetActive(true);
            SpaceDown.SetActive(false);
        }

        if (timePassed > 5f && timePassed < 6f)
        {
            SpaceUp.SetActive(false);
            SpaceDown.SetActive(true);
        }
    }
}
