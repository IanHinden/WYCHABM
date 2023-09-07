using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FullCoins : MonoBehaviour
{
    [SerializeField] GameObject Ava;
    [SerializeField] Controller controller;
    [SerializeField] UIHandler uihandler;
    [SerializeField] ScoreHandler scorehandler;
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] TextMeshProUGUI displayscore;
    //Animator starAnim;

    [SerializeField] Coin coin;

    SpriteRenderer avaSprite;

    int totalCoins;
    int remainingCoins;

    private bool levelComplete = false;

    void Awake()
    {
        Coin.CoinGet += MinusCoin;
        StolenWages.WagesGet += StolenWagesRecovered;
        avaSprite = Ava.GetComponent<SpriteRenderer>();
        Reset();
        //starAnim = threeSecondsLeft.transform.Find("CountdownImages").transform.GetChild(3).transform.GetChild(2).GetComponent<Animator>();
    }

    private void CoinSpwaner()
    {
        Coin coin1 = Instantiate(coin, transform);
        coin1.transform.localPosition = new Vector3(-2.14f, -1.91f, 0);
        coin1.transform.rotation = Quaternion.identity;

        Coin coin2 = Instantiate(coin, transform);
        coin2.transform.localPosition = new Vector3(0.07f, -1.91f, 0);
        coin2.transform.rotation = Quaternion.identity;

        Coin coin3 = Instantiate(coin, transform);
        coin3.transform.localPosition = new Vector3(2.08f, -1.91f, 0);
        coin3.transform.rotation = Quaternion.identity;

        Coin coin4 = Instantiate(coin, transform);
        coin4.transform.localPosition = new Vector3(-2.14f, -0.52f, 0);
        coin4.transform.rotation = Quaternion.identity;

        Coin coin5 = Instantiate(coin, transform);
        coin5.transform.localPosition = new Vector3(0.07f, -0.52f, 0);
        coin5.transform.rotation = Quaternion.identity;

        Coin coin6 = Instantiate(coin, transform);
        coin6.transform.localPosition = new Vector3(2.08f, -0.52f, 0);
        coin6.transform.rotation = Quaternion.identity;
    }

    private void StolenWagesRecovered(int amount)
    {
        levelComplete = true;
        scorehandler.IncrementScore();
        //threeSecondsLeft.DisplayBonusScoreCard(starAnim);
        uihandler.WinDisplay();
        controller.OnDisable();
    }

    private void MinusCoin(int amount)
    {
        remainingCoins--;
        if (remainingCoins == 0 && levelComplete == false)
        {
            levelComplete = true;
            uihandler.WinDisplay();
            scorehandler.IncrementScore();
            controller.OnDisable();
        }
        displayscore.text = totalCoins - remainingCoins + "/" + totalCoins;
    }

    public IEnumerator WinOrLose()
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(7));

        if (levelComplete == false)
        {
            DetermineWinOrLoss();
        }
    }

    private void DetermineWinOrLoss()
    {
        if (!levelComplete)
        {
            if (remainingCoins == 0)
            {
                uihandler.WinDisplay();
                controller.OnDisable();
                scorehandler.IncrementScore();
            }
            else
            {
                uihandler.LoseDisplay();
                controller.OnDisable();
            }
        }
    }

    private void CoinReset()
    {
        CoinDestroy();
        CoinSpwaner();

        totalCoins = 6;
        remainingCoins = totalCoins;

        displayscore.text = totalCoins - remainingCoins + "/" + totalCoins;
    }

    public void Reset()
    {
        CoinReset();
        Ava.transform.position = new Vector3(-3.508f, 0.266f, 36.627f);
        if(avaSprite != null) avaSprite.color = new Color(1, 1, 1, 1); 
        levelComplete = false;
    }

    private void CoinDestroy()
    {
        foreach (Transform child in transform)
        {
            // Destroy each child.
            Destroy(child.gameObject);
        }
    }
}
