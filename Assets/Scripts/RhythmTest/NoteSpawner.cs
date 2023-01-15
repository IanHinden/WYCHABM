using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField] GameObject blackdot;
    private List<float> pauses = new List<float> {.16f, .2f, .16f, .2f, .16f, .4f, 1.6f, .16f, .2f, .18f, .18f, .18f, .36f, .3f, .36f };
    
    void Awake()
    {
        StartCoroutine(PlayNotes());
    }

    IEnumerator PlayNotes()
    {
        yield return new WaitForSeconds(4.4f);
        foreach(float pause in pauses)
        {
            yield return new WaitForSeconds(pause);
            Instantiate(blackdot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
