using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public IEnumerator MoveToBackroom()
    {
        Vector3 targetPosition = new Vector3(-17.8f, 0f, -10f);

        float elapsedTime = 0;
        float waitTime = 20f;

        while (elapsedTime < waitTime)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, (elapsedTime/waitTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
