using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsychoAnimationController : MonoBehaviour
{
    [SerializeField] GameObject oedipaBonus;
    [SerializeField] GameObject freudStickHolder;
    [SerializeField] GameObject freudStick;

    Animator oedipalBonusAnim;
    Animator freudStickHolderAnim;
    Animator freudStickAnim;
    void Awake()
    {
        oedipalBonusAnim = oedipaBonus.GetComponent<Animator>();
        freudStickHolderAnim = freudStickHolder.GetComponent<Animator>();
        freudStickAnim = freudStick.GetComponent<Animator>();
    }

    public void RaisePopsicleStick()
    {
        freudStickHolderAnim.SetTrigger("Raise");
    }

    public void WigglePopsicleStick()
    {
        freudStickAnim.SetTrigger("Wiggle");
    }

    public void StartOedipalBonus()
    {
        oedipaBonus.SetActive(true);
        oedipalBonusAnim.SetTrigger("Bonus");
    }

    public void Reset()
    {
        if (oedipalBonusAnim != null)
        {
            oedipaBonus.SetActive(false);
            oedipalBonusAnim.ResetTrigger("Bonus");
            freudStickHolderAnim.ResetTrigger("Raise");
            freudStickAnim.ResetTrigger("Wiggle");
        }

        freudStickHolder.transform.position = new Vector3(0, 0, 0);
        //Code to reset freud picture and stick to initial value
    }
}
