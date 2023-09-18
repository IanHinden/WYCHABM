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
            Vector3 currentPosition = new Vector3(transform.position.x, transform.position.y, 1);
            myLine.updateLine(currentPosition);
        }
    }

    public void createLine()
    {
        GameObject newLine = Instantiate(linePrefab);
        myLine = newLine.GetComponent<penLine>();
        myLine.transform.parent = this.transform;

        LineRenderer line = newLine.GetComponent<LineRenderer>();
        line.sortingOrder = 8;
    }

    public void DeletePenLine()
    {
        if (myLine != null)
        {
            myLine.ResetLine();
        }
    }
}
