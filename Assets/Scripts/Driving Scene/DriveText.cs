using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveText : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine(TextTiming());
    }

    IEnumerator TextTiming()
    {
        yield return new WaitForSeconds(3.5f);
        ToggleVisibility(true);
        yield return new WaitForSeconds(1f);
        ToggleVisibility(false);
    }

    public void ToggleVisibility(bool visible)
    {
        SpriteRenderer rend = gameObject.GetComponent<SpriteRenderer>();

        rend.enabled = visible;
    }
}
