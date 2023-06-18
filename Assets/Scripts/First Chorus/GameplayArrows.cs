using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayArrows : MonoBehaviour
{
    float speed = 200f;

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);    
    }
}
