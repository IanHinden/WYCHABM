using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongTimeDisplay : MonoBehaviour
{
    public float time = 0;
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        time += Time.deltaTime;
        Debug.Log(time);
    }
}
