using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Heart heart;
    Animator heartAnim;

    [SerializeField] RichmondLips richmondLips;
    Rigidbody2D richmondLipsRB;

    [SerializeField] Missus missus;
    Rigidbody2D missusRB;

    [SerializeField] LeftHeart leftHeart;
    [SerializeField] RightHeart rightHeart;
    Animator leftHeartAnim;
    Animator rightHeartAnim;

    [SerializeField] KissCover kiss;
    [SerializeField] HitCover hit;
    Animator kissCover;
    Animator hitCover;

    [SerializeField] SpankArm spankArm;
    [SerializeField] SpankMark spankMark;
    Animator spankMarkAnim;

    [SerializeField] Legs legs;
    [SerializeField] Spotlight spotLight;

    private bool kissTriggered = false;
    private bool hitTriggered = false;

    void Awake()
    {
        heartAnim = heart.GetComponent<Animator>();
        richmondLipsRB = richmondLips.GetComponent<Rigidbody2D>();
        missusRB = missus.GetComponent<Rigidbody2D>();
        spankMarkAnim = spankMark.GetComponent<Animator>();
        leftHeartAnim = leftHeart.GetComponent<Animator>();
        rightHeartAnim = rightHeart.GetComponent<Animator>();
        kissCover = kiss.GetComponent<Animator>();
        hitCover = hit.GetComponent<Animator>();
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
            leftHeartAnim.SetTrigger("Break");
            rightHeartAnim.SetTrigger("Break");
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
            spankMarkAnim.SetTrigger("Spank");
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

    public bool ReturnHitTriggered()
    {
        return hitTriggered;
    }

    public void CoverSwitch()
    {
        hitCover.SetTrigger("Cover");
        kissCover.SetTrigger("Cover");
    }
}
