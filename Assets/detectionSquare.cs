using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class detectionSquare : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] GameObject perfect;
    [SerializeField] GameObject good;

    private Animator anim;
    private float measure;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        measure = timefunctions.ReturnSingleMeasure();
        StartCoroutine(Blink());
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        float distance = Vector3.Distance(transform.position, col.gameObject.transform.position);
        if(distance <= 3)
        {
            SpawnPerfect();
        } else if (distance > 3 && distance < 7)
        {
            SpawnGood();
        }
        Destroy(col.gameObject);
    }

    private void SpawnPerfect()
    {
        GameObject perfectSign = Instantiate(perfect, new Vector3(640f, 360f, 0), Quaternion.identity);
        perfectSign.transform.SetParent(transform);
    }

    private void SpawnGood()
    {
        GameObject goodSign = Instantiate(good, new Vector3(640f, 360f, 0), Quaternion.identity);
        goodSign.transform.SetParent(transform);
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            anim.SetTrigger("Blink");
            yield return new WaitForSeconds(measure / 2);
        }
    }
}
