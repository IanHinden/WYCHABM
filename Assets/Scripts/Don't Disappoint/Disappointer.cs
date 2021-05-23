using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappointer : MonoBehaviour
{
    SuccessOrFail successOrFail;
    // Start is called before the first frame update
    void Awake()
    {
        successOrFail = gameObject.AddComponent<SuccessOrFail>();
        StartCoroutine(WinOrLose());
    }

    IEnumerator WinOrLose()
    {
        yield return new WaitForSeconds(4f);
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        Debug.Log("It happen");
        successOrFail.LoseDisplay();
    }
}
