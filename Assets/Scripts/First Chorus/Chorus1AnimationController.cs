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
        yield return new WaitForSeconds(timeFunctions.ReturnSingleMeasure() * 2);
        Chorus1AvaAnim.SetTrigger("Enter");
        yield return new WaitForSeconds(timeFunctions.ReturnSingleMeasure() * 4);
        Chorus1RRAnim.SetTrigger("Enter");
    }

    public void Reset()
    {
        if (Chorus1AvaAnim != null)
        {
            Chorus1Ava.transform.position = new Vector3(-8.16f, -0.53f, 0f);
            Chorus1Ava.transform.eulerAngles = new Vector3(0, 0, 10);
            Chorus1AvaAnim.ResetTrigger("Enter");

            Chorus1RR.transform.position = new Vector3(8.69f, -0.49f, 0f);
            Chorus1RR.transform.eulerAngles = new Vector3(0, 0, 20);
            Chorus1RRAnim.ResetTrigger("Enter");
        }
    }
}
