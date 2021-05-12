using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    SuccessOrFail successOrFail;
    // Start is called before the first frame update
    void Awake()
    {
        successOrFail = gameObject.AddComponent<SuccessOrFail>();
        StartCoroutine(WinOrLose());
    }

    public int GetRemainingCoins()
    {
        int remainingCoins = gameObject.transform.childCount;
        return remainingCoins;
    }

    // Update is called once per frame
    void Update()
    {
        int remainingCoins = GetRemainingCoins();
        if(remainingCoins == 0)
        {
            successOrFail.WinDisplay();
        }
    }

    IEnumerator WinOrLose()
    {
        yield return new WaitForSeconds(4f);
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        int remainingCoins = GetRemainingCoins();
        if(remainingCoins == 0)
        {
            successOrFail.WinDisplay();
        } else
        {
            successOrFail.LoseDisplay();
        }
    }
}
