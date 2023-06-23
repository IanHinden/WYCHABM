using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class detectionSquare : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        print("Entered");
        //based on distance from point, deliver rating
        float distance = Vector3.Distance(transform.position, col.gameObject.transform.position);
        Debug.Log(distance);

        Destroy(col.gameObject);
    }
}
