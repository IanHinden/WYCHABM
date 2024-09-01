using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterObjects : MonoBehaviour
{
    [SerializeField] GameObject Zero;
    [SerializeField] GameObject One;
    [SerializeField] GameObject Two;
    [SerializeField] GameObject Three;
    [SerializeField] GameObject Four;
    [SerializeField] GameObject Five;
    [SerializeField] GameObject Six;
    [SerializeField] GameObject Seven;
    [SerializeField] GameObject Eight;
    [SerializeField] GameObject Nine;
    [SerializeField] GameObject Ten;
    [SerializeField] GameObject Eleven;

    List<GameObject> allRects = new List<GameObject>();

    private float interval = .01f;
    public bool pass = false;
    public bool kissHitAchi = false;

    int currentRect = 0;
    private bool animating = true;
    private bool onTheWayUp = true;

    void Awake()
    {
        allRects.Add(Zero);
        allRects.Add(One);
        allRects.Add(Two);
        allRects.Add(Three);
        allRects.Add(Four);
        allRects.Add(Five);
        allRects.Add(Six);
        allRects.Add(Seven);
        allRects.Add(Eight);
        allRects.Add(Nine);
        allRects.Add(Ten);
        allRects.Add(Eleven);

        //StartCoroutine(StartMeter());
    }

    public bool getPass()
    {
        return pass;
    }

    public bool getKissHitAchi()
    {
        if(currentRect == 12)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public IEnumerator StartMeter()
    {
        while(animating == true) {
            while (onTheWayUp == true)
            {

                foreach (GameObject rect in allRects)
                {
                    yield return new WaitForSeconds(interval);
                    currentRect++;

                    if (currentRect == 10)
                    {
                        pass = true;
                    }

                    rect.SetActive(true);
                }

                onTheWayUp = false;
            }

            while (onTheWayUp == false)
            { 
                for (int i = allRects.Count - 1; i >= 0; i--)
                {
                    yield return new WaitForSeconds(interval);
                    currentRect--;

                    if (currentRect == 9)
                    {
                        pass = false;
                    }

                    GameObject currRect = allRects[i];
                    currRect.SetActive(false);
                }

                onTheWayUp = true;
            }

            if(Eleven.activeSelf == true)
            {
                kissHitAchi = true;
            } else
            {
                kissHitAchi = false;
            }
        }
    }


    public void StopRoutine()
    {
        animating = false;
        HighlightRect(currentRect);
    }

    private void HighlightRect(int rect)
    {
        for (int i = 0; i < rect; i++)
        {
            GameObject currRect = allRects[i];
            currRect.SetActive(true);
        }
    }

    public void ResetMeter()
    {
        pass = false;
        currentRect = 0;
        animating = false;

        for (int i = 0; i < allRects.Count; i++)
        {
            GameObject currRect = allRects[i];
            currRect.SetActive(false);
        }

        onTheWayUp = true;
        animating = true;
    }
}
