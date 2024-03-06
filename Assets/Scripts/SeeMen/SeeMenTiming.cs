using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeMenTiming : MonoBehaviour
{
    [SerializeField] GameObject dancingRichman;

    private Animator dancingRichmanAnim;
    void Awake()
    {
        dancingRichmanAnim = dancingRichman.GetComponent<Animator>();
    }

    public IEnumerator Dance()
    {
        yield return new WaitForSeconds(1.1f);
        dancingRichmanAnim.SetBool("Dance", true);
    }

    public void Reset()
    {
        if (dancingRichmanAnim != null)
        {
            dancingRichmanAnim.SetBool("Dance", false);
        }
    }
}
