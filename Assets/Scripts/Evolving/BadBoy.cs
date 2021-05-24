using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadBoy : MonoBehaviour
{
    private Image badBoy;
    // Start is called before the first frame update
    void Start()
    {
        badBoy = gameObject.GetComponent<Image>();
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        yield return new WaitForSeconds(1);
        badBoy.enabled = false;
        yield return new WaitForSeconds(1);
        badBoy.enabled = true;
        yield return new WaitForSeconds(1);
        badBoy.enabled = false;
    }
}
