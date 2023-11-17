using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backroom : MonoBehaviour
{
    [SerializeField] FullCoins fullCoins;

    [SerializeField] Camera maincamera;
    [SerializeField] GameObject Ava;
    [SerializeField] GameObject Ava2;

    BoxCollider2D backroomCol;
    CapsuleCollider2D capCol;

    SpriteRenderer AvaSR;
    Animator AvaAnim;

    private bool moved = false;

    private void Awake()
    {
        AvaSR = Ava.GetComponent<SpriteRenderer>();
        AvaAnim = Ava2.GetComponent<Animator>();
        backroomCol = gameObject.GetComponent<BoxCollider2D>();
        capCol = gameObject.GetComponent<CapsuleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        fullCoins.setLevelComplete();
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
            alpha -= 0.10f;
            tmp.a = alpha;
            AvaSR.color = tmp;

            yield return new WaitForSeconds(0.00000005f); // update interval
        }
    }

    public void ToggleTrigger(bool on)
    {
        if (backroomCol != null)
        {
            backroomCol.enabled = on;
            capCol.enabled = !on;
        }
    }
}
