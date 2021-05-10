using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingerBehavior : MonoBehaviour
{
    GameObject singer;
    GameObject lyricsBackground;
    void Start()
    {
        singer = GameObject.Find("Canvas").transform.Find("Ian").gameObject;
        lyricsBackground = GameObject.Find("Canvas").transform.Find("Lyric Background").gameObject;
        StartCoroutine(MoveIntoPlaceSinger(3f));
        StartCoroutine(MoveIntoPlaceText(3f));
    }

    IEnumerator MoveIntoPlaceSinger(float time)
    {
        yield return new WaitForSeconds(2);

        Vector3 startingPos = singer.transform.position;
        Vector3 finalPos = singer.transform.position - (singer.transform.right * 7000);

        Vector3 startingPosLyrics = lyricsBackground.transform.position;
        Vector3 finalPosLyrics = lyricsBackground.transform.position + (lyricsBackground.transform.up * 1500);

        float elapsedTime = 0;

        while (singer.transform.position.x > 700)
        {
            singer.transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            lyricsBackground.transform.position = Vector3.Lerp(startingPosLyrics, finalPosLyrics, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }

    IEnumerator MoveIntoPlaceText(float time)
    {
        yield return new WaitForSeconds(2);

        Vector3 startingPosLyrics = lyricsBackground.transform.position;
        Vector3 finalPosLyrics = lyricsBackground.transform.position + (lyricsBackground.transform.up * 7000);

        float elapsedTime = 0;

        while (lyricsBackground.transform.position.x > 700)
        {
            lyricsBackground.transform.position = Vector3.Lerp(startingPosLyrics, finalPosLyrics, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
