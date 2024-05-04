using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditHolder : MonoBehaviour
{
    public float speed = 1.0f; // adjust the speed to your liking

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public void ResetPos()
    {
        this.gameObject.transform.localPosition = new Vector3(0, -659, 0);
    }
}
