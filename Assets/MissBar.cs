using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissBar : MonoBehaviour
{
    [SerializeField] GameObject miss;
    void OnTriggerEnter2D(Collider2D col)
    {
        SpawnMiss();
    }

    private void SpawnMiss()
    {
        GameObject missSign = Instantiate(miss, new Vector3(640f, 360f, 0), Quaternion.identity);
        missSign.transform.SetParent(transform);
    }
}
