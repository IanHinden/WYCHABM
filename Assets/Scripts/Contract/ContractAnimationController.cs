using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractAnimationController : MonoBehaviour
{
    [SerializeField] GameObject Pointing;
    [SerializeField] GameObject Clapping;
    [SerializeField] GameObject WatchingObjects;
    [SerializeField] GameObject Watching1;
    [SerializeField] GameObject Watching2;

    Coroutine watchFlipCo;

    public void setPointing()
    {
        Pointing.SetActive(true);
        Clapping.SetActive(false);
        WatchingObjects.SetActive(false);
        StopWatch();
    }

    public void setClapping()
    {
        Pointing.SetActive(false);
        Clapping.SetActive(true);
        WatchingObjects.SetActive(false);
        StopWatch();
    }

    public void setWatching()
    {
        Pointing.SetActive(false);
        Clapping.SetActive(false);
        WatchingObjects.SetActive(true);

        watchFlipCo = StartCoroutine(WatchFlip());
    }

    private IEnumerator WatchFlip()
    {
        while (true)
        {
            Watching1.SetActive(true);
            Watching2.SetActive(false);
            yield return new WaitForSeconds(.5f);
            Watching1.SetActive(false);
            Watching2.SetActive(true);
            yield return new WaitForSeconds(.5f);
        }
    }

    private void StopWatch()
    {
        if (watchFlipCo != null) StopCoroutine(watchFlipCo);
    }

    public IEnumerator PlayRandomAnimation()
    {
        while (true)
        {
            float randomWaitTime = Random.Range(.4f, .8f);
            yield return new WaitForSeconds(randomWaitTime);

            int randomFunctionIndex = Random.Range(0, 3);
            switch (randomFunctionIndex)
            {
                case 0:
                    setPointing();
                    break;
                case 1:
                    setClapping();
                    break;
                case 2:
                    setWatching();
                    break;
            }
        }
    }
}
