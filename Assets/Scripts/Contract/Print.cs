using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Print : MonoBehaviour
{
    [SerializeField] public Ink ink;

    public GameObject linePrefab;
    private penLine myLine;

    void Awake()
    {
        GameObject newLine = Instantiate(linePrefab);
        myLine = newLine.GetComponent<penLine>();
        myLine.transform.parent = this.transform;
    }

    public void InkSpawner()
    {
        //StartCoroutine(InkLine());
        if (myLine != null)
        {
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
            myLine.updateLine(currentPosition);
        }
    }


    /*
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
    */
}
