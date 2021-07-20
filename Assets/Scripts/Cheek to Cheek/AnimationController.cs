using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator heartAnim;
    RichmondLips richmondLips;
    Rigidbody2D richmondLipsRB;
    Rigidbody2D missusRB;

    Animator leftHeart;
    Animator rightHeart;

    Animator kissCover;
    Animator hitCover;

    SpankArm spankArm;
    Animator spankMark;

    Legs legs;

    private bool kissTriggered = false;
    private bool hitTriggered = false;

    void Awake()
    {
        heartAnim = FindObjectOfType<Heart>().GetComponent<Animator>();
        richmondLips = FindObjectOfType<RichmondLips>();
        richmondLipsRB = richmondLips.GetComponent<Rigidbody2D>();
        missusRB = FindObjectOfType<Missus>().GetComponent<Rigidbody2D>();
        spankArm = FindObjectOfType<SpankArm>();
        legs = FindObjectOfType<Legs>();
        spankMark = FindObjectOfType<SpankMark>().GetComponent<Animator>();
        leftHeart = FindObjectOfType<LeftHeart>().GetComponent<Animator>();
        rightHeart = FindObjectOfType<RightHeart>().GetComponent<Animator>();
        kissCover = FindObjectOfType<KissCover>().GetComponent<Animator>();
        hitCover = FindObjectOfType<HitCover>().GetComponent<Animator>();
    }

    void Update()
    {
        spankArm.Spank();
        legs.LegsUp();
    }

    public void KissWinAnimation()
    {
        if (kissTriggered == false)
        {
            heartAnim.SetTrigger("Success");
            StartCoroutine(KissMove());
            kissTriggered = true;
        }
    }

    private IEnumerator KissMove()
    {
        richmondLipsRB.velocity = transform.right * -2;
        yield return new WaitForSeconds(.5f);
        richmondLipsRB.velocity = Vector3.zero;
        yield return null;
    }

    public void KissLoseAnimation()
    {
        if (kissTriggered == false)
        {
            StartCoroutine(MissMove());
            leftHeart.SetTrigger("Break");
            rightHeart.SetTrigger("Break");
            kissTriggered = true;
        }
    }

    private IEnumerator MissMove()
    {
        missusRB.velocity = transform.right * -5;
        yield return null;
    }

    public void HitWinAnimation()
    {
        if(hitTriggered == false){
            spankArm.StartSpank();
            spankMark.SetTrigger("Spank");
            hitTriggered = true;
        }
    }

    public void HitLoseAnimation()
    {
        if (hitTriggered == false)
        {
            legs.StartLegsUp();
            hitTriggered = true;
        }
    }

    public bool ReturnKissTriggered()
    {
        return kissTriggered;
    }

    public void CoverSwitch()
    {
        hitCover.SetTrigger("Cover");
        kissCover.SetTrigger("Cover");
    }
}
