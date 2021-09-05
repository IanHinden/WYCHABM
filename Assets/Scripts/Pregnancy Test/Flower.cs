using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public GameObject smallDroplet;
    public GameObject mediumDroplet;
    public GameObject largeDroplet;

    public float respawnTime = 1.0f;

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(spray());
    }

    private void spawnDroplet()
    {
        GameObject droplet = Instantiate(smallDroplet) as GameObject;
        droplet.transform.position = this.transform.position;
    }

    // Update is called once per frame
    IEnumerator spray()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnDroplet();
        }
    }
}
