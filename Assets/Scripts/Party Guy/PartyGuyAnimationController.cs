using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyGuyAnimationController : MonoBehaviour
{
    [SerializeField] GameObject bP2NiteText;
    [SerializeField] GameObject hellYeahText;

    Animator bP2NiteTextAnim;
    Animator hellYeahTextAnim;
    void Awake()
    {
        bP2NiteTextAnim = bP2NiteText.GetComponent<Animator>();
        hellYeahTextAnim = hellYeahText.GetComponent<Animator>();
    }

    public void sendBP2NiteText()
    {
        bP2NiteTextAnim.SetTrigger("TextAppear");
    }

    public void sendHellYeahText()
    {
        hellYeahTextAnim.SetTrigger("TextAppear");
    }

    public void Reset()
    {
        bP2NiteTextAnim.ResetTrigger("TextAppear");
        hellYeahTextAnim.ResetTrigger("TextAppear");

        bP2NiteText.transform.position = new Vector3(2.32f, 0.62f, 0f);
        bP2NiteText.transform.localScale = new Vector3(0.4632813f, 0.005172801f, .4632813f);

        hellYeahText.transform.position = new Vector3(6.61f, -1.44f, 0f);
        hellYeahText.transform.localScale = new Vector3(0.4632813f, 0.00059877f, 0.4632813f);
    }
}
