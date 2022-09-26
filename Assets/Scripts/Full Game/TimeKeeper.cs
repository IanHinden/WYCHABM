using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(SwitchScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(2);
        Camera.current.transform.Translate(61.1f, 0, 0);

    }
}
