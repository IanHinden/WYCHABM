using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contract : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] ScoreHandler scorehandler;

    [SerializeField] ContractAnimationController contractAnimationController;

    [SerializeField] Hand hand;
    [SerializeField] new Print print;

    public IEnumerator WinOrLose()
    {
        StartCoroutine(contractAnimationController.PlayRandomAnimation());
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(4));
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        bool moved = hand.getMoved();
        if (moved)
        {
            uihandler.LoseDisplay();
        }
        else
        {
            scorehandler.IncrementScore();
            uihandler.WinDisplay();
        }
    }

    public void Reset()
    {
        hand.transform.position = new Vector3(0f, -0.021f, 0f);
        hand.resetMoved();
        print.DeletePenLine();
        print.createLine();
    }
}
