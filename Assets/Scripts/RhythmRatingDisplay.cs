using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
using UnityEngine.UI;

public class RhythmRatingDisplay : MonoBehaviour
{
    [SerializeField] Image missFlat;
    [SerializeField] Image perfectFlat;
    [SerializeField] Image notbadFlat;

    private Animator missFlatAnim;
    private Animator perfectFlatAnim;
    private Animator notbadFlatAnim;

    private Image missFlatImage;
    private Image perfectFlatImage;
    private Image notbadFlatImage;

    void Awake()
    {
        missFlatAnim = missFlat.GetComponent<Animator>();
        missFlatImage = missFlat.GetComponent<Image>();

        perfectFlatAnim = perfectFlat.GetComponent<Animator>();
        perfectFlatImage = perfectFlat.GetComponent<Image>();

        notbadFlatAnim = notbadFlat.GetComponent<Animator>();
        notbadFlatImage = notbadFlat.GetComponent<Image>();
    }

    public void SetPerfect()
    {
        ClearText();

        perfectFlatAnim.Play("New State", -1, 0);
        perfectFlatImage.enabled = true;
        perfectFlatAnim.SetTrigger("Animate");
    }

    public void SetGood()
    {
        ClearText();

        notbadFlatAnim.Play("New State", -1, 0);
        notbadFlatImage.enabled = true;
        notbadFlatAnim.SetTrigger("Animate");
    }

    public void SetMiss()
    {
        ClearText();

        missFlatAnim.Play("New State", -1, 0);
        missFlatImage.enabled = true;
        missFlatAnim.SetTrigger("Animate");
    }

    public void ClearText()
    {
        missFlatImage.enabled = false;
        perfectFlatImage.enabled = false;
        notbadFlatImage.enabled = false;
    }
}
