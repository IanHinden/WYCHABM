using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabCheck : MonoBehaviour
{
    //SuccessOrFail successOrFail;
    ThreeSecondsLeft threeSecondsLeft;
    public GameObject oedipalBonus;

    bool stabbed = false;
    bool oedipal = false;

    private void Awake()
    {
        //successOrFail = gameObject.AddComponent<SuccessOrFail>();
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
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
        threeSecondsLeft.WinDisplay();
    }

    IEnumerator WinOrLose()
    {
        float timeToEnd = threeSecondsLeft.ReturnTimeToEnd() + 2 * threeSecondsLeft.ReturnSingleMeasure();

        yield return new WaitForSeconds(3f);
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        if (stabbed == false)
        {
            threeSecondsLeft.LoseDisplay();
        }
    }
}
