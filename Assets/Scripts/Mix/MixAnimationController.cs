using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixAnimationController : MonoBehaviour
{
    [SerializeField] GameObject MoonCloseEye;
    [SerializeField] GameObject MoonOpenEye;

    [Header("Clouds")]
    [SerializeField] Transform clouds;

    SpriteRenderer moonCloseEyeSR;
    SpriteRenderer moonOpenEyeSR;

    void Awake()
    {
        moonCloseEyeSR = MoonCloseEye.GetComponent<SpriteRenderer>();
        moonOpenEyeSR = MoonOpenEye.GetComponent<SpriteRenderer>();
    }

    public void LoseAnimation()
    {
        moonOpenEyeSR.enabled = false;
        moonCloseEyeSR.enabled = true;

        foreach (Transform child in clouds)
        {
            // Check if the child has an Animator component
            Animator animator = child.GetComponent<Animator>();

            if (animator != null)
            {
                // Replace "YourTriggerName" with the name of your trigger
                animator.SetTrigger("Lose");
            }
        }
    }
}
