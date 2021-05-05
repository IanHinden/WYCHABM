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

    public void InkSpawner()
    {
        StartCoroutine(InkLine());
    }

    private void spawnInk()
    {
        GameObject inkBlot = Instantiate(ink) as GameObject;
        inkBlot.transform.position = gameObject.transform.position;
    }

    private IEnumerator InkLine()
    {
        yield return new WaitForSeconds(.1f);
        spawnInk();
    }

    void FixedUpdate()
    {
        
    }
}
