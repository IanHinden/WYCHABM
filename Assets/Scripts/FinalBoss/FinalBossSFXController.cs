using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossSFXController : MonoBehaviour
{
    [SerializeField] AudioSource richmanLaugh;

    public void PlayRichmanLaugh()
    {
        richmanLaugh.Play();
    }
}
