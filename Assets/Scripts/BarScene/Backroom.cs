using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backroom : MonoBehaviour
{
    [SerializeField] Camera maincamera;
    [SerializeField] GameObject Ava;
    [SerializeField] GameObject Ava2;

    SpriteRenderer AvaSR;
    Animator AvaAnim;

    private bool moved = false;

    private void Awake()
    {
        AvaSR = Ava.GetComponent<SpriteRenderer>();
        AvaAnim = Ava2.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (moved == false)
        {
            StartCoroutine(MoveToBackroom());
        }
    }

    public IEnumerator MoveToBackroom()
    {
        moved = true;
        Vector3 targetPosition = new Vector3(-17.8f, 0f, -10f);
        float alpha = AvaSR.color.a;
        Color tmp = AvaSR.color;

        float elapsedTime = 0;
        float waitTime = .6f;

        while (elapsedTime < waitTime)
        {
            maincamera.transform.position = Vector3.Lerp(transform.position, targetPosition, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        AvaAnim.SetTrigger("Start");

        while (AvaSR.color.a > 0)
        {
            alpha -= 0.01f;
            tmp.a = alpha;
            AvaSR.color = tmp;

            yield return new WaitForSeconds(0.00000005f); // update interval
        }
    }
}
