using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backroom : MonoBehaviour
{
    [SerializeField] Camera maincamera;
    private bool moved = false;

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

        float elapsedTime = 0;
        float waitTime = .3f;

        while (elapsedTime < waitTime)
        {
            maincamera.transform.position = Vector3.Lerp(transform.position, targetPosition, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
