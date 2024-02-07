using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabCheck : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] ScoreHandler scorehandler;

    [SerializeField] PsychoAnimationController psychoAnimationController;
    [SerializeField] PsychoSFXController psychoSFXController;

    [SerializeField] GameObject liveDaddy;
    [SerializeField] GameObject deadDaddy;

    [SerializeField] Hands hands;

    public GameObject oedipalBonus;

    bool stabbed = false;
    bool oedipal = false;
    bool levelEnded = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "OedipalBonusSpawner")
        {
            if (levelEnded == false)
            {
                Vector3 textPos = transform.position;
                textPos.x = transform.position.x + 15;
                psychoSFXController.PlayOediplayBonus();
                psychoAnimationController.StartOedipalBonus();
                StartCoroutine(FreudStickVictory());
                if (oedipal == false)
                {
                    scorehandler.IncrementScore();
                    uihandler.WinDisplay();
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
            scorehandler.IncrementScore();
        }
    }

    public IEnumerator FreudStickVictory()
    {
        psychoAnimationController.RaisePopsicleStick();
        yield return new WaitForSeconds(1f);
        psychoAnimationController.WigglePopsicleStick();
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
        stabbed = false;
        oedipal = false;
        levelEnded = false;
        liveDaddy.SetActive(true);
        deadDaddy.SetActive(false);
        hands.removeStabHoles();
        hands.transform.position = new Vector3(2.75f, -.99f, 0);
        psychoAnimationController.Reset();
    }
}
