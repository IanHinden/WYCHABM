using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsychoAnimationController : MonoBehaviour
{
    [SerializeField] GameObject oedipaBonus;

    Animator oedipalBonusAnim;
    void Awake()
    {
        oedipalBonusAnim = oedipaBonus.GetComponent<Animator>();
    }

    public void StartOedipalBonus()
    {
        oedipaBonus.SetActive(true);
        oedipalBonusAnim.SetTrigger("Bonus");
    }

    public void Reset()
    {
        oedipaBonus.SetActive(false);
        oedipalBonusAnim.ResetTrigger("Bonus");
    }
}
