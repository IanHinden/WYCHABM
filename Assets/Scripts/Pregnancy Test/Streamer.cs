﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Streamer : MonoBehaviour
{
    public GameObject smallDroplet;
    public GameObject mediumDroplet;
    public GameObject largeDroplet;

    public float respawnTime = .1f;

    public Transform shotPoint;

    /*void Awake()
    {
        InvokeRepeating("spawnDroplet", 0, 0.1f);
    }*/

    public void HoldIt()
    {
        CancelInvoke();
    }

    public void StartStream()
    {
        InvokeRepeating("spawnDroplet", 0, 0.05f);
    }

    private void spawnDroplet()
    {
        float rand = Random.Range(0, 3);
        float offset = Random.Range(-.2f, .2f);
        GameObject dropType;

        if (rand == 0)
        {
            dropType = smallDroplet;
        }
        else if (rand == 1)
        {
            dropType = mediumDroplet;
        }
        else
        {
            dropType = largeDroplet;
        }

        Instantiate(dropType, shotPoint.position + new Vector3(offset, 0, 0), transform.rotation);
    }
}
