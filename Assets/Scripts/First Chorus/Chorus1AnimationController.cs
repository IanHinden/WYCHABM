using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chorus1AnimationController : MonoBehaviour
{
    [SerializeField] TimeFunctions timeFunctions;

    [SerializeField] GameObject Chorus1Ava;
    [SerializeField] GameObject Chorus1RR;

    Animator Chorus1AvaAnim;
    Animator Chorus1RRAnim;
    void Awake()
    {
        Chorus1AvaAnim = Chorus1Ava.GetComponent<Animator>();
        Chorus1RRAnim = Chorus1RR.GetComponent<Animator>();

        StartCoroutine(CardAnimations());
    }

    private IEnumerator CardAnimations()
    {
        yield return new WaitForSeconds(timeFunctions.ReturnSingleMeasure());
        Chorus1AvaAnim.SetTrigger("Enter");
        yield return new WaitForSeconds(timeFunctions.ReturnSingleMeasure());
        Chorus1RRAnim.SetTrigger("Enter");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
