using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixAnimationController : MonoBehaviour
{
    [SerializeField] GameObject Moon;
    [SerializeField] GameObject Sun;

    [SerializeField] GameObject MoonCloseEye;
    [SerializeField] GameObject MoonOpenEye;

    [SerializeField] GameObject nightBackground;

    [SerializeField] GameObject nightLight;
    [SerializeField] GameObject dayLight;

    [Header("Clouds")]
    [SerializeField] Transform clouds;
    [SerializeField] GameObject clouds1;
    [SerializeField] GameObject clouds2;
    [SerializeField] GameObject clouds3;
    [SerializeField] GameObject clouds4;

    SpriteRenderer nightBackgroundSR;
    SpriteRenderer nightLightSR;
    SpriteRenderer dayLightSR;
    SpriteRenderer moonCloseEyeSR;
    SpriteRenderer moonOpenEyeSR;

    Animator moonAnim;
    Animator sunAnim;
    Animator nightBackgroundAnim;
    Animator nightLightAnim;
    Animator dayLightAnim;

    void Awake()
    {
        nightBackgroundSR = nightBackground.GetComponent<SpriteRenderer>();
        nightLightSR = nightLight.GetComponent<SpriteRenderer>();
        dayLightSR = dayLight.GetComponent<SpriteRenderer>();

        moonCloseEyeSR = MoonCloseEye.GetComponent<SpriteRenderer>();
        moonOpenEyeSR = MoonOpenEye.GetComponent<SpriteRenderer>();

        moonAnim = Moon.GetComponent<Animator>();
        sunAnim = Sun.GetComponent<Animator>();

        nightBackgroundAnim = nightBackground.GetComponent<Animator>();
        nightLightAnim = nightLight.GetComponent<Animator>();
        dayLightAnim = dayLight.GetComponent<Animator>();
    }

    public void WinAnimation()
    {
        moonOpenEyeSR.enabled = false;
        moonCloseEyeSR.enabled = true;

        moonAnim.SetTrigger("Win");
        sunAnim.SetTrigger("Win");
        nightBackgroundAnim.SetTrigger("Win");
        nightLightAnim.SetTrigger("Win");
        dayLightAnim.SetTrigger("Win");
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

    public void Reset()
    {
        if (moonOpenEyeSR != null)
        {
            moonOpenEyeSR.enabled = true;
            moonCloseEyeSR.enabled = false;

            foreach (Transform child in clouds)
            {
                // Check if the child has an Animator component
                Animator animator = child.GetComponent<Animator>();

                if (animator != null)
                {
                    // Replace "YourTriggerName" with the name of your trigger
                    animator.ResetTrigger("Lose");
                }
            }

            moonAnim.ResetTrigger("Win");
            sunAnim.ResetTrigger("Win");
            nightBackgroundAnim.ResetTrigger("Win");
            nightLightAnim.ResetTrigger("Win");
            dayLightAnim.ResetTrigger("Win");

            Moon.transform.position = new Vector3(0, 0, 0);
            Sun.transform.position = new Vector3(12.26f, 1.47f, 0);

            nightBackgroundSR.color = new Color(1, 1, 1, 1);
            nightLightSR.color = new Color(1, 1, 1, 1);
            dayLightSR.color = new Color(1, 1, 1, 0);

            clouds1.transform.position = new Vector3(-.03f, .35f, 0);
            clouds2.transform.position = new Vector3(-.03f, .35f, 0);
            clouds3.transform.position = new Vector3(-.03f, .35f, 0);
            clouds4.transform.position = new Vector3(3.1f, .35f, 0);
        }
    }
}
