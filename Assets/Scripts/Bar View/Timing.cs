using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timing : MonoBehaviour
{
    [SerializeField] UIHandler uiHandler;

    [SerializeField] GameObject waitress;
    [SerializeField] Camera mainCamera;

    public IEnumerator WaitressMove()
    {
        uiHandler.InsertCoinsTextEnter();
        waitress.transform.position = new Vector3(-0.63f, -0.13f, 0f);
        yield return new WaitForSeconds(.5f);
        waitress.transform.position = new Vector3(-0.39f, -0.1f, 0f);
        yield return new WaitForSeconds(.5f);
        waitress.transform.position = new Vector3(-0.14f, -0.38f, 0f);
        yield return new WaitForSeconds(.5f);
        waitress.transform.position = new Vector3(0f, 0f, 0f);
        yield return new WaitForSeconds(1f);

        float zoomDuration = 1f;
        float startTime = Time.time;
        float startOrthographicSize = mainCamera.orthographicSize;
        Vector3 startPosition = mainCamera.transform.position;

        while (Time.time - startTime < zoomDuration)
        {
            float t = (Time.time - startTime) / zoomDuration;
            mainCamera.orthographicSize = Mathf.Lerp(startOrthographicSize, 3.5f, t);
            mainCamera.transform.position = Vector3.Lerp(startPosition, new Vector3(-2.32f, 0.81f, -10f), t);
            yield return null;
        }
    }

    public void Reset()
    {
        uiHandler.ResetInsertCoinsText();
    }
}
