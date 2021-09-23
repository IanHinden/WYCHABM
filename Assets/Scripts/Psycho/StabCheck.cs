using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabCheck : MonoBehaviour
{
    SuccessOrFail successOrFail;
    ThreeSecondsLeft threeSecondsLeft;
    public GameObject oedipalBonus;

    bool stabbed = false;
    bool oedipal = false;

    private void Awake()
    {
        successOrFail = gameObject.AddComponent<SuccessOrFail>();
        threeSecondsLeft = gameObject.AddComponent<ThreeSecondsLeft>();
        StartCoroutine(WinOrLose());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "OedipalBonus")
        {
            Vector3 textPos = transform.position;
            textPos.x = transform.position.x - 3;
            Instantiate(oedipalBonus, textPos, Quaternion.identity);
            oedipal = true;
        }
        stabbed = true;
    }

    IEnumerator WinOrLose()
    {
        float timeToEnd = threeSecondsLeft.ReturnTimeToEnd() + 2 * threeSecondsLeft.ReturnSingleMeasure();

        yield return new WaitForSeconds(timeToEnd);
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        if (stabbed)
        {
            threeSecondsLeft.DisplayScoreCard();
            successOrFail.WinDisplay();
        }
        else
        {
            successOrFail.LoseDisplay();
        }
    }
}
