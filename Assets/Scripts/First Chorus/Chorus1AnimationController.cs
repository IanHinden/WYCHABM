using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chorus1AnimationController : MonoBehaviour
{
    [SerializeField] TimeFunctions timeFunctions;

    [SerializeField] GameObject Chorus1Ava;
    [SerializeField] GameObject Chorus1RR;

    [SerializeField] GameObject Would;
    [SerializeField] GameObject You;
    [SerializeField] GameObject Call;
    [SerializeField] GameObject Him;
    [SerializeField] GameObject Badman;

    Animator Chorus1AvaAnim;
    Animator Chorus1RRAnim;
    void Awake()
    {
        Chorus1AvaAnim = Chorus1Ava.GetComponent<Animator>();
        Chorus1RRAnim = Chorus1RR.GetComponent<Animator>();

        StartCoroutine(CardAnimations());
        StartCoroutine(LyricsTimer());
    }

    private IEnumerator CardAnimations()
    {
        yield return new WaitForSeconds(timeFunctions.ReturnSingleMeasure() * 2);
        Chorus1AvaAnim.SetTrigger("Enter");
        yield return new WaitForSeconds(timeFunctions.ReturnSingleMeasure() * 4);
        Chorus1RRAnim.SetTrigger("Enter");
    }

    private IEnumerator LyricsTimer()
    {
        yield return new WaitForSeconds(7.524022f);
        Would.SetActive(true);
        You.SetActive(true);
        yield return new WaitForSeconds(0.2102633f);
        Call.SetActive(true);
        yield return new WaitForSeconds(0.1721108f);
        Him.SetActive(true);
        yield return new WaitForSeconds(0.1680734f);
        Badman.SetActive(true);
        //yield return new WaitForSeconds(0.1945287f);
        //yield return new WaitForSeconds(0.5377512f);
        //yield return new WaitForSeconds(0.5015675f);
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

            Would.SetActive(false);
            You.SetActive(false);
            Call.SetActive(false);
            Him.SetActive(false);
            Badman.SetActive(false);
        }
    }
}
