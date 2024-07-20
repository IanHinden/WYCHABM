using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilLightning : MonoBehaviour
{
    private SpriteRenderer lightningSR;

    private void Awake()
    {
        lightningSR = this.GetComponent<SpriteRenderer>();
    }
    private void LightningStrike()
    {
        StartCoroutine(lightningAnimation());
    }

    private IEnumerator lightningAnimation()
    {
        int flashes = 3;
        while (flashes > 0)
        {
            lightningSR.enabled = true;
            yield return new WaitForSeconds(.05f);
            lightningSR.enabled = false;
            yield return new WaitForSeconds(.05f);
            flashes--;
        }
    }
}
