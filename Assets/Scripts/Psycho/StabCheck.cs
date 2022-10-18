using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabCheck : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;
    [SerializeField] TimeFunctions timefunctions;

    public GameObject oedipalBonus;

    bool stabbed = false;
    bool oedipal = false;
    bool levelEnded = false;

    private void Awake()
    {
        StartCoroutine(WinOrLose());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "OedipalBonus")
        {
            if (levelEnded == false)
            {
                Vector3 textPos = transform.position;
                textPos.x = transform.position.x - 3;
                Instantiate(oedipalBonus, textPos, Quaternion.identity);
                if (oedipal == false)
                {
                    //threeSecondsLeft.DisplayScoreCard();
                    uihandler.WinDisplay();
                    //threeSecondsLeft.DisplayBonusScoreCard(starAnim);
                    oedipal = true;
                    levelEnded = true;
                }
            }
        }
        stabbed = true;
        if (levelEnded == false)
        {
            uihandler.WinDisplay();
        }
    }

    IEnumerator WinOrLose()
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(5));
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        if (stabbed == false && levelEnded == false)
        {
            levelEnded = true;
            uihandler.LoseDisplay();
        }
    }
}
