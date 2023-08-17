using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAJobTime : MonoBehaviour
{
    [SerializeField] TimeFunctions timeFunctions;

    [SerializeField] GameObject eyesPlaying;
    [SerializeField] GameObject eyesShocked;
    [SerializeField] GameObject portableGamingDeviceInHand;
    [SerializeField] GameObject portableGamingDeviceFalling;

    private Animator portableGamingDeviceAnimation;

    void Awake()
    {
        portableGamingDeviceAnimation = portableGamingDeviceFalling.GetComponent<Animator>(); 
    }

    public IEnumerator AllEvents()
    {
        yield return new WaitForSeconds(2f);
        eyesPlaying.SetActive(false);
        eyesShocked.SetActive(true);
        portableGamingDeviceInHand.SetActive(false);
        portableGamingDeviceFalling.SetActive(true);
        portableGamingDeviceAnimation.SetTrigger("Drop");
    }

    public void Reset()
    {
        eyesPlaying.SetActive(true);
        eyesShocked.SetActive(false);
        portableGamingDeviceInHand.SetActive(true);
        portableGamingDeviceFalling.SetActive(false);
    }
}
