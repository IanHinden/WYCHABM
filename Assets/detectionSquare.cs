using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class detectionSquare : MonoBehaviour
{
    [SerializeField] RhythmRatingDisplay rhythmRatingDisplay;

    public static float score = 0;

    void OnTriggerEnter2D(Collider2D col)
    {
        float distance = Vector3.Distance(transform.position, col.gameObject.transform.position);
        if(distance <= 3)
        {
            SpawnPerfect();
            score = score + 2;
        } else if (distance > 3 && distance < 7)
        {
            score = score + 1;
            SpawnGood();
        }

        Image arrowImage = col.gameObject.GetComponent<Image>();
        BoxCollider2D arrowBC = col.gameObject.GetComponent<BoxCollider2D>();
        arrowImage.enabled = false;
        arrowBC.enabled = false;

    }

    private void SpawnPerfect()
    {
        rhythmRatingDisplay.SetPerfect();
    }

    private void SpawnGood()
    {
        rhythmRatingDisplay.SetGood();
    }

    public float getScore()
    {
        return score;
    }

    public void resetScore()
    {
        score = 0;
    }
}
