using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Print : MonoBehaviour
{
    [SerializeField] public Ink ink;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InkSpawner()
    {
        StartCoroutine(InkLine());
    }

    private void spawnInk()
    {
        Ink inkBlot = Instantiate(ink) as Ink;
        inkBlot.transform.position = this.transform.position;
    }

    private IEnumerator InkLine()
    {
        yield return new WaitForSeconds(.1f);
        spawnInk();
    }
}
