using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeSpawner : MonoBehaviour
{
    [SerializeField] GameObject cone;
    private float spawnVelocity = 50f;

    public void SpawnCone()
    {
        GameObject spawnedCone = Instantiate(cone, transform.position, transform.rotation);
        spawnedCone.GetComponent<Rigidbody2D>().velocity = Vector3.down * spawnVelocity;
    }
}
