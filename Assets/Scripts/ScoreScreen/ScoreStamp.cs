using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreStamp : MonoBehaviour
{
    [SerializeField] Image RotateCat;
    [SerializeField] Image SGrade;
    [SerializeField] Image AGrade;
    [SerializeField] Image BGrade;
    [SerializeField] Image CGrade;
    [SerializeField] Image DGrade;
    [SerializeField] Image FGrade;

    Animator stampAnim;

    private void Awake()
    {
        stampAnim = this.GetComponent<Animator>();
    }

    public void SetGrade(string grade)
    {
        HideAllGrade();

        if (grade == "S")
        {
            SGrade.enabled = true;
        } else if (grade == "A")
        {
            AGrade.enabled = true;
        } else if (grade == "B")
        {
            BGrade.enabled = true;
        } else if (grade == "C")
        {
            CGrade.enabled = true;
        } else if (grade == "D")
        {
            DGrade.enabled = true;
        } else if (grade == "F")
        {
            FGrade.enabled = true;
        }
    }

    public void HideAllGrade()
    {
        SGrade.enabled = false;
        AGrade.enabled = false;
        BGrade.enabled = false;
        CGrade.enabled = false;
        DGrade.enabled = false;
        FGrade.enabled = false;
    }

    public void AnimateStamp()
    {
        stampAnim.SetBool("ScoreStamp", true);
        RotateCat.enabled = true;
    }

    public void ResetStamp()
    {
        HideAllGrade();
        stampAnim.SetBool("ScoreStamp", false);
        this.transform.localScale = new Vector3(2, 2, 2);
        RotateCat.enabled = false;
    }
}
