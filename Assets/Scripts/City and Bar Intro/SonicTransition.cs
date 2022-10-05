using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicTransition : MonoBehaviour
{
    [SerializeField] GameObject red;
    [SerializeField] GameObject blue;
    [SerializeField] GameObject yellow;

    Animator redAnim;
    Animator blueAnim;
    Animator yellowAnim;

    void Awake()
    {
        redAnim = red.GetComponent<Animator>();
        blueAnim = blue.GetComponent<Animator>();
        yellowAnim = yellow.GetComponent<Animator>();
        StartCoroutine(SonicEnter());
    }

    IEnumerator SonicEnter()
    {
        yield return new WaitForSeconds(12f);
        redAnim.SetTrigger("StartAnim");
        blueAnim.SetTrigger("StartAnim");
        yellowAnim.SetTrigger("StartAnim");
        yield return new WaitForSeconds(3f);
        redAnim.SetTrigger("ExitAnim");
        blueAnim.SetTrigger("ExitAnim");
        yellowAnim.SetTrigger("ExitAnim");
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
