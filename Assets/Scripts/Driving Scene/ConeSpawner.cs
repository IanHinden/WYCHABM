using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeSpawner : MonoBehaviour
{
    [SerializeField] GameObject cone;
    [SerializeField] GameObject coneHolder;
    private float spawnVelocity = 70f;

    public void SpawnCone()
    {
        float horizontalOffset = Random.Range(-0.5f, 0.5f);

        GameObject spawnedCone = Instantiate(cone, transform.position, transform.rotation);
        spawnedCone.transform.parent = coneHolder.transform;
        spawnedCone.GetComponent<Rigidbody2D>().velocity = Vector3.down * spawnVelocity + Vector3.right * horizontalOffset * spawnVelocity;
    }
}
