using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabCheck : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] ScoreHandler scorehandler;

    [SerializeField] GameObject liveDaddy;
    [SerializeField] GameObject deadDaddy;

    [SerializeField] Hands hands;

    public GameObject oedipalBonus;

    bool stabbed = false;
    bool oedipal = false;
    bool levelEnded = false;

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
                    scorehandler.IncrementScore();
                    uihandler.WinDisplay();
                    //threeSecondsLeft.DisplayBonusScoreCard(starAnim);
                    liveDaddy.SetActive(false);
                    deadDaddy.SetActive(true);
                    oedipal = true;
                    levelEnded = true;
                }
            }
        }
        stabbed = true;
        if (levelEnded == false)
        {
            liveDaddy.SetActive(false);
            deadDaddy.SetActive(true);
            uihandler.WinDisplay();
        }
    }

    public IEnumerator WinOrLose()
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

    public void Reset()
    {
        liveDaddy.SetActive(true);
        deadDaddy.SetActive(false);
        hands.removeStabHoles();
        hands.transform.position = new Vector3(5.26f, -2.46f, 0);
    }
}
