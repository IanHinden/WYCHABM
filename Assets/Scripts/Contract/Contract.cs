using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contract : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] ScoreHandler scorehandler;
    [SerializeField] Hand hand;
    [SerializeField] Print print;

    [SerializeField] GameObject Pointing;
    [SerializeField] GameObject Clapping;

    public IEnumerator WinOrLose()
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(3));
        Pointing.SetActive(false);
        Clapping.SetActive(true);
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(1));
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
        hand.transform.position = new Vector3(3.07f, -1.49f, 0f);
        hand.resetMoved();
        print.DeletePenLine();
        print.createLine();
    }
}
