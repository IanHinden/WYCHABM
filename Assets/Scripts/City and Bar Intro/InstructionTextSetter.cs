using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionTextSetter : MonoBehaviour
{
    private Animator anim;
    private TextMeshProUGUI textmesh;

    [SerializeField] string instructions;
    [SerializeField] float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        textmesh = GetComponent<TextMeshProUGUI>();
        StartCoroutine(InstructionText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InstructionText()
    {
        yield return new WaitForSeconds(waitTime);
        textmesh.text = instructions;
        anim.SetTrigger("StartAnim");
    }
}
