using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holding : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;
    // Start is called before the first frame update
    void Awake()
    {
        dialogue.QuickExit();
    }
}
