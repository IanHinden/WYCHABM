using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator heartAnim;
    Rigidbody2D richmondLipsRB;

    void Awake()
    {
        heartAnim = FindObjectOfType<Heart>().GetComponent<Animator>();
        richmondLipsRB = FindObjectOfType<RichmondLips>().GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    public void KissWinAnimation()
    {
        heartAnim.SetTrigger("Success");
        StartCoroutine(KissMove());
    }

    private IEnumerator KissMove()
    {
        richmondLipsRB.velocity = transform.right * -2;
        yield return new WaitForSeconds(.5f);
        richmondLipsRB.velocity = Vector3.zero;
        yield return null;
    }
}
