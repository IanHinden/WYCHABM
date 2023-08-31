﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avas : MonoBehaviour
{
    private GameObject Ava1;
    private GameObject Ava2;
    void Awake()
    {
        Ava1 = transform.GetChild(0).gameObject;
        Ava2 = transform.GetChild(1).gameObject;
        StartCoroutine(Sway());
    }

    IEnumerator Sway()
    {
        yield return new WaitForSeconds(1.3f);
        Ava1.SetActive(true);
        yield return new WaitForSeconds(.7f);
        Swap();
        yield return new WaitForSeconds(.3f);
        Swap();
        yield return new WaitForSeconds(.3f);
        Swap();
        yield return new WaitForSeconds(.3f);
        Swap();
        yield return new WaitForSeconds(.3f);
        Swap();
        yield return new WaitForSeconds(.3f);
        Swap();
        yield return new WaitForSeconds(.3f);
        Swap();
        yield return new WaitForSeconds(.3f);
        Swap();
        yield return new WaitForSeconds(.3f);
    }

    private void Swap()
    {
        Ava1.SetActive(!Ava1.activeSelf);
        Ava2.SetActive(!Ava2.activeSelf); 
    }
}