﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public GameObject smallDroplet;
    public GameObject mediumDroplet;
    public GameObject largeDroplet;

    public float respawnTime = .1f;
    public float respawnTimeCopy;

    // Start is called before the first frame update
    void Awake()
    {
        InvokeRepeating("spawnDroplet", 0, 0.1f);
    }


    private void spawnDroplet()
    {
        GameObject droplet = Instantiate(smallDroplet) as GameObject;
        droplet.transform.position = this.transform.position;
    }
}
