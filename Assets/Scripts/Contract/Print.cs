using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Print : MonoBehaviour
{
    [SerializeField] public GameObject ink;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void spawnInk()
    {
        GameObject inkBlot = Instantiate(ink) as GameObject;
        inkBlot.transform.position = gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spawnInk();
    }
}
