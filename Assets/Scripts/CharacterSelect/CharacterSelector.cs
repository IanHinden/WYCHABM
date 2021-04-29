using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    // Start is called before the first frame update
    Character[] characters;
    void Start()
    {
        characters = FindObjectsOfType<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
