using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabCheck : MonoBehaviour
{
    //SuccessOrFail successOrFail;
    ThreeSecondsLeft threeSecondsLeft;
    SceneSwitch sceneSwitch;
    public GameObject oedipalBonus;

    bool stabbed = false;
    bool oedipal = false;

    private void Awake()
    {
        //successOrFail = gameObject.AddComponent<SuccessOrFail>();
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
        sceneSwitch = FindObjectOfType<SceneSwitch>();
        StartCoroutine(WinOrLose());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "OedipalBonus")
        {
            Vector3 textPos = transform.position;
            textPos.x = transform.position.x - 3;
            Instantiate(oedipalBonus, textPos, Quaternion.identity);
            oedipal = true;
        }
        stabbed = true;
        threeSecondsLeft.WinDisplay();
    }

    IEnumerator WinOrLose()
    {
        float deadline = sceneSwitch.ReturnTimeToSwitch() - threeSecondsLeft.ReturnTimeToEnd() + (3 * threeSecondsLeft.ReturnSingleMeasure());

        yield return new WaitForSeconds(deadline);
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        if (stabbed == false)
        {
            threeSecondsLeft.LoseDisplay();
        }
    }
}
