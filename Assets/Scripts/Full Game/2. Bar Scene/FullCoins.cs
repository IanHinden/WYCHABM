using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FullCoins : MonoBehaviour
{
    [SerializeField] GameObject Ava;
    [SerializeField] Controller controller;
    [SerializeField] UIHandler uihandler;
    [SerializeField] Dialogue dialogue;
    [SerializeField] ScoreHandler scorehandler;
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] TextMeshProUGUI displayscore;
    [SerializeField] GameObject coinCollect;

    [SerializeField] Coin coin;
    [SerializeField] Backroom backroom;
    [SerializeField] GameObject officeLight;

    SpriteRenderer avaSprite;

    Animator officeLightAnim;

    AudioSource coinCollectSound;

    int timeBeforeDoorClose = 3;

    int totalCoins;
    int remainingCoins;

    private bool levelComplete = false;
    private bool bonusWin = false;

    Coroutine repeatCoinSoundCo;

    void Awake()
    {
        Coin.CoinGet += MinusCoin;
        avaSprite = Ava.GetComponent<SpriteRenderer>();
        officeLightAnim = officeLight.GetComponent<Animator>();
        coinCollectSound = coinCollect.GetComponent<AudioSource>();
        Reset();
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

    private void MinusCoin(int amount)
    {
        remainingCoins--;
        coinCollectSound.Play();
        if (remainingCoins == 0 && levelComplete == false)
        {
            levelComplete = true;
            uihandler.WinDisplay();
            scorehandler.IncrementScore(1);
            controller.OnDisable();
        }
        displayscore.text = totalCoins - remainingCoins + "/" + totalCoins;
    }

    public IEnumerator WinOrLose()
    {
        yield return new WaitForSeconds(2);
        dialogue.DialogueEnter("IAN H.");
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(timeBeforeDoorClose) -2);

        CloseDoor();

        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(7 - timeBeforeDoorClose));

        if (levelComplete == false || bonusWin == true)
        {
            DetermineWinOrLoss();
        }
    }

    private void DetermineWinOrLoss()
    {
        if (!levelComplete)
        {
            uihandler.LoseDisplay();
            controller.OnDisable();
            /*if (remainingCoins == 0)
            {
                uihandler.WinDisplay();
                controller.OnDisable();
                scorehandler.IncrementScore();
            }
            else
            {*/
            //}
        }

        if (bonusWin == true)
        {
            scorehandler.IncrementScore(1);
            scorehandler.IncrementBonusScore(1);
            uihandler.WinDisplay();
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
        backroom.Reset();
        if(officeLightAnim != null) officeLightAnim.ResetTrigger("Close");
        if(repeatCoinSoundCo != null) StopCoroutine(repeatCoinSoundCo);
        bonusWin = false;

        officeLight.transform.position = new Vector3(-7.507f, -0.463f, 0);
        officeLight.transform.localScale = new Vector3(0.1268785f, 0.1268785f, 0.1268785f);
    }

    private void CoinDestroy()
    {
        foreach (Transform child in transform)
        {
            // Destroy each child.
            Destroy(child.gameObject);
        }
    }

    public void setLevelComplete()
    {
        levelComplete = true;
    }

    public IEnumerator setBonusWin()
    {
        bonusWin = true;
        long score = 10;

        repeatCoinSoundCo = StartCoroutine(RepeatCoinSound());

        while (score < 50000000)
        {
            score = score + 654321;
            displayscore.text = score + "/" + totalCoins;
            yield return new WaitForSeconds(.001f);
        }

        StopCoroutine(repeatCoinSoundCo);

        displayscore.text = "50 BILLION/" + totalCoins;
    }

    private IEnumerator RepeatCoinSound()
    {
        while (true)
        {
            coinCollectSound.Play();
            yield return new WaitForSeconds(.01f);
        }
    }

    private void CloseDoor()
    {
        officeLightAnim.SetTrigger("Close");
        backroom.ToggleTrigger(false);
    }
}
