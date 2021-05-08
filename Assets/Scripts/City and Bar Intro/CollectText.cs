using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectText : MonoBehaviour
{
    private Animator anim;
    private TextMeshProUGUI textmesh;
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
        yield return new WaitForSeconds(14.5f);
        textmesh.text = "Collect";
        anim.SetTrigger("StartAnim");
    }
}
