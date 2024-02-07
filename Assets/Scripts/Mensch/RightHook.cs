using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHook : MonoBehaviour
{
    [SerializeField] MenschAudioController menschAudioController;

    private void PlayPunchSFX()
    {
        menschAudioController.PlayPunch();
    }
}
