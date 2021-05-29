using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabCheck : MonoBehaviour
{
    SuccessOrFail successOrFail;
    bool stabbed = false;

    private void Awake()
    {
        successOrFail = gameObject.AddComponent<SuccessOrFail>();
        StartCoroutine(WinOrLose());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        stabbed = true;
    }

    IEnumerator WinOrLose()
    {
        yield return new WaitForSeconds(5f);
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        if (stabbed)
        {
            successOrFail.WinDisplay();
        }
        else
        {
            successOrFail.LoseDisplay();
        }
    }
}
