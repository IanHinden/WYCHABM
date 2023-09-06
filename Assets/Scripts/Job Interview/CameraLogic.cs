using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    [SerializeField] GameObject threedcam;

    bool isMoving = false;
    /*private void Awake()
    {
        StartCoroutine(moveToX(threedcam.transform, new Vector3(5.9f, 10.59f, -10), .5f));
    }*/

    public IEnumerator moveToX(Vector3 toPosition, float duration)
    {
        yield return new WaitForSeconds(.5f);
        //Make sure there is only one instance of this function running
        if (isMoving)
        {
            yield break; ///exit if this is still running
        }
        isMoving = true;

        float counter = 0;

        //Get the current position of the object to be moved
        Vector3 startPos = threedcam.transform.position;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            threedcam.transform.position = Vector3.Lerp(startPos, toPosition, counter / duration);
            yield return null;
        }

        isMoving = false;
    }
}
