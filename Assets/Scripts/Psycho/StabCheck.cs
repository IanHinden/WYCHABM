using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabCheck : MonoBehaviour
{
    //SuccessOrFail successOrFail;
    ThreeSecondsLeft threeSecondsLeft;

    Animator starAnim;

    public GameObject oedipalBonus;

    bool stabbed = false;
    bool oedipal = false;
    bool levelEnded = false;

    private void Awake()
    {
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();

        starAnim = threeSecondsLeft.transform.Find("CountdownImages").transform.GetChild(3).transform.GetChild(4).GetComponent<Animator>();
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
                    threeSecondsLeft.DisplayBonusScoreCard(starAnim);
                    oedipal = true;
                }
            }
        }
        stabbed = true;
        if (levelEnded == false)
        {
            threeSecondsLeft.WinDisplay();
        }
    }

    IEnumerator WinOrLose()
    {
        float deadline = (5 * threeSecondsLeft.ReturnSingleMeasure());

        yield return new WaitForSeconds(deadline);
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        if (stabbed == false && levelEnded == false)
        {
            levelEnded = true;
            threeSecondsLeft.LoseDisplay();
        }
    }
}
