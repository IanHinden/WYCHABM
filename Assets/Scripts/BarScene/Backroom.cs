using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backroom : MonoBehaviour
{
    [SerializeField] FullCoins fullCoins;

    [SerializeField] Camera maincamera;
    [SerializeField] GameObject Ava;
    [SerializeField] GameObject Ava2;

    [SerializeField] GameObject bonusCollectSFX;

    BoxCollider2D backroomCol;
    CapsuleCollider2D capCol;

    SpriteRenderer AvaSR;
    SpriteRenderer Ava2SR;
    Animator AvaAnim;

    AudioSource bonusCollectSFXAS;

    private bool moved = false;

    private void Awake()
    {
        AvaSR = Ava.GetComponent<SpriteRenderer>();
        Ava2SR = Ava2.GetComponent<SpriteRenderer>();
        AvaAnim = Ava2.GetComponent<Animator>();
        backroomCol = gameObject.GetComponent<BoxCollider2D>();
        capCol = gameObject.GetComponent<CapsuleCollider2D>();
        bonusCollectSFXAS = bonusCollectSFX.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        fullCoins.setLevelComplete();
        fullCoins.setBonusWin();
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
        yield return new WaitForSeconds(2f);
        bonusCollectSFXAS.Play();
    }

    public void ToggleTrigger(bool on)
    {
        if (backroomCol != null)
        {
            backroomCol.enabled = on;
            capCol.enabled = !on;
        }
    }

    public void Reset()
    {
        moved = false;
        if (Ava2SR != null)
        {
            Ava2.transform.position = new Vector3(-11.11f, 2.266f, 36.627f);
            Ava2SR.color = new Color(255, 255, 255, 0);
        }

        ToggleTrigger(true);
    }
}
