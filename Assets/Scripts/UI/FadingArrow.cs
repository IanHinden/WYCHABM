using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingArrow : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(DestroySelf());
    }

    private IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(.34f);
        Destroy(this.gameObject);
    }
}
