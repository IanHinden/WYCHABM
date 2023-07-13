using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Print : MonoBehaviour
{
    public GameObject linePrefab;
    private penLine myLine;

    void Awake()
    {
        createLine();
    }

    public void InkSpawner()
    {
        if (myLine != null)
        {
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
            myLine.updateLine(currentPosition);
        }
    }

    public void createLine()
    {
        GameObject newLine = Instantiate(linePrefab);
        myLine = newLine.GetComponent<penLine>();
        myLine.transform.parent = this.transform;
    }

    public void DeletePenLine()
    {
        myLine.ResetLine();
    }
}
