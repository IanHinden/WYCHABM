using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissBar : MonoBehaviour
{
    [SerializeField] RhythmRatingDisplay rhythmRatingDisplay;

    void OnTriggerEnter2D(Collider2D col)
    {
        SpawnMiss();

        Image arrowImage = col.gameObject.GetComponent<Image>();
        BoxCollider2D arrowBC = col.gameObject.GetComponent<BoxCollider2D>();
        arrowImage.enabled = false;
        arrowBC.enabled = false;
    }

    private void SpawnMiss()
    {
        rhythmRatingDisplay.SetMiss();
    }
}
