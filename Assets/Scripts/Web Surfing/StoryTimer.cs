using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryTimer : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;

    [SerializeField] GameObject computerScreen;
    [SerializeField] GameObject pointer;

    Animator pointerAnim;

    private SpriteRenderer pointerSR;
 
    void Awake()
    {
        pointerAnim = pointer.GetComponent<Animator>();
        pointerSR = pointer.GetComponent<SpriteRenderer>();
    }

    public IEnumerator timedEvents()
    {

        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(4));
        computerScreen.SetActive(true);
        pointerSR.enabled = true;
        pointerAnim.SetTrigger("Pointer");
    }

    public void Reset()
    {
        computerScreen.SetActive(false);
        pointerSR.enabled = false;
    }
}
