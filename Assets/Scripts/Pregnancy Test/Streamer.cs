using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Streamer : MonoBehaviour
{
    [SerializeField] PregnancySFXController pregnancySFXController;

    [SerializeField] GameObject peeholder;

    public GameObject smallDroplet;
    public GameObject mediumDroplet;
    public GameObject largeDroplet;

    public float respawnTime = .1f;

    public Transform shotPoint;

    public void HoldIt()
    {
        pregnancySFXController.StopStream();
        CancelInvoke();
    }

    public void StartStream()
    {
        pregnancySFXController.PlayUnzip();
        pregnancySFXController.PlayStream();
        InvokeRepeating("spawnDroplet", 0, 0.06f);
        //HoldIt();
        //InvokeRepeating("spawnDroplet", 0, 0.1f);
    }

    public void RemoveAllDroplets()
    {
        for(int i = peeholder.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(peeholder.transform.GetChild(i).gameObject);
        }
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

        GameObject droplet = Instantiate(dropType, shotPoint.position + new Vector3(offset, 0, 0), transform.rotation);
        droplet.transform.SetParent(peeholder.transform);
    }
}
