using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MicrogameInstructionText : MonoBehaviour
{
    private TextMeshPro textmesh;
    private Animator anim;

    [SerializeField] string instructions;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        textmesh = this.gameObject.GetComponent<TextMeshPro>();
        anim = gameObject.GetComponent<Animator>();
    }

    public void InstructionText()
    {
        StartCoroutine(AnimateAndDestroy());
    }

    private IEnumerator AnimateAndDestroy()
    {
        textmesh.text = instructions;
        anim.SetTrigger("StartAnim");
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
