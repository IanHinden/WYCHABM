using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] GameObject pop;

    private SpriteRenderer popSR;
    private SpriteRenderer bubbleSR;
    void Awake()
    {
        bubbleSR = gameObject.GetComponent<SpriteRenderer>();
        popSR = pop.GetComponent<SpriteRenderer>();
    }

    public IEnumerator Pop()
    {
        bubbleSR.enabled = false;
        popSR.enabled = true;
        yield return new WaitForSeconds(.2f);
        popSR.enabled = false;
    }

    public void Reset()
    {
        if(bubbleSR != null)
        {
            popSR.enabled = false;
            bubbleSR.enabled = true;
        }
    }
}
