using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField] GameObject leftArrow;
    [SerializeField] GameObject rightArrow;
    [SerializeField] GameObject upArrow;
    [SerializeField] GameObject downArrow;

    [SerializeField] TimeFunctions timeFunctions;

    float measure;
    float quarter;
    void Awake()
    {
        measure = timeFunctions.ReturnSingleMeasure();
        quarter = timeFunctions.ReturnQuarterNote();

        StartCoroutine(SpawnNotes());
    }

    private IEnumerator SpawnNotes()
    {
        yield return new WaitForSeconds(2 * quarter);
        yield return new WaitForSeconds(1 * measure);
        yield return new WaitForSeconds(2 * quarter);
        Spawner();
        yield return new WaitForSeconds(quarter);
        Spawner();
        yield return new WaitForSeconds(quarter);
        Spawner();
        yield return new WaitForSeconds(quarter);
        Spawner();
        yield return new WaitForSeconds(quarter);
        Spawner();
        yield return new WaitForSeconds(2 * quarter);
        Spawner();
    }

    private void Spawner()
    {
        GameObject arrow = Instantiate(leftArrow, transform);
        arrow.transform.localPosition = new Vector3(0, 0, 0);
        arrow.transform.rotation = Quaternion.identity;
    }
}
