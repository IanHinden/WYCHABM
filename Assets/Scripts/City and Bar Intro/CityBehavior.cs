using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBehavior : MonoBehaviour
{
    [SerializeField] GameObject city;

    Animator avaAnimator;
    void Awake()
    {
        StartCoroutine(CityOff());

        avaAnimator = FindObjectOfType<Ava>().GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    IEnumerator CityOff()
    {
        yield return new WaitForSeconds(2);
        city.SetActive(false);

        avaAnimator.SetTrigger("Enter");
    }
}
