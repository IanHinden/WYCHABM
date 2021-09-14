using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBehavior : MonoBehaviour
{
    [SerializeField] GameObject city;

    Animator avaAnimator;

    PittiePartyDialogue pittiePartyDialogue;
    void Awake()
    {
        StartCoroutine(StartAnimations());

        avaAnimator = FindObjectOfType<Ava>().GetComponent<Animator>();
        pittiePartyDialogue = FindObjectOfType<PittiePartyDialogue>();
    }

    void Update()
    {
        
    }

    IEnumerator StartAnimations()
    {
        yield return new WaitForSeconds(2);
        city.SetActive(false);

        avaAnimator.SetTrigger("Enter");
        StartCoroutine(pittiePartyDialogue.SetAvaDialogue());
    }
}
