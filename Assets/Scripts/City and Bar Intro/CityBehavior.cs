using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityBehavior : MonoBehaviour
{
    GameObject cityScape;

    float scrollSpeed = 35f;
    private void Awake()
    {
        cityScape = GameObject.Find("Canvas").transform.Find("CityScape").gameObject;
        StartCoroutine(Disappear());
    }

    // Update is called once per frame
    void Update()
    {
        cityScape.transform.position += new Vector3(1, 1, 0) * Time.deltaTime * scrollSpeed;
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(3);
        cityScape.SetActive(false);
    }
}
