using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
    [SerializeField] private GameObject CityAndBarIntro;
    [SerializeField] private GameObject BarScene;
    [SerializeField] private GameObject Contract;
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
        yield return new WaitForSeconds(3);
        CityAndBarIntro.SetActive(false);
        BarScene.SetActive(true);
        Camera.current.transform.Translate(61.1f, 0, 0);
        yield return new WaitForSeconds(3);
        BarScene.SetActive(false);
        Contract.SetActive(true);
        Camera.current.transform.Translate(30.3f, 0, 0);

    }
}
