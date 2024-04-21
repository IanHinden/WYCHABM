using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBorder : MonoBehaviour
{
    private RectTransform imageRectTransform;
    private Animator imageAnim;
    private void Awake()
    {
        imageRectTransform = this.gameObject.GetComponent<RectTransform>();
        imageAnim = this.gameObject.GetComponent<Animator>();
    }

    private void ResetAnimLoop()
    {
        imageRectTransform.anchoredPosition = new Vector2(177.49997f, 90f);
        imageAnim.SetTrigger("Start");
        imageAnim.ResetTrigger("Start");
    }
}
