using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectSFXController : MonoBehaviour
{
    [SerializeField] GameObject HighlightSFX;
    [SerializeField] GameObject ConfirmSFX;

    [SerializeField] GameObject OFselectedSFX;
    [SerializeField] GameObject HomelessSelectedSFX;
    [SerializeField] GameObject CongresswomanSelectedSFX;

    private AudioSource HighlightSFXAS;
    private AudioSource ConfirmSFXAS;

    private AudioSource OFSelectedSFXAS;
    private AudioSource HomelessSelectedSFXAS;
    private AudioSource CongresswomanSelectedSFXAS;

    void Awake()
    {
        HighlightSFXAS = HighlightSFX.GetComponent<AudioSource>();
        ConfirmSFXAS = ConfirmSFX.GetComponent<AudioSource>();

        OFSelectedSFXAS = OFselectedSFX.GetComponent<AudioSource>();
        HomelessSelectedSFXAS = HomelessSelectedSFX.GetComponent<AudioSource>();
        CongresswomanSelectedSFXAS = CongresswomanSelectedSFX.GetComponent<AudioSource>();
    }

    public void PlayHighlight()
    {
        HighlightSFXAS.Play();
    }

    public void PlayConfirm()
    {
        ConfirmSFXAS.Play();
    }

    public IEnumerator PlayOFSelected()
    {
        yield return new WaitForSeconds(.3f);
        OFSelectedSFXAS.Play();
    }

    public IEnumerator PlayHomelessSelected()
    {
        yield return new WaitForSeconds(.3f);
        HomelessSelectedSFXAS.Play();
    }

    public IEnumerator PlayCongresswomanSelected()
    {
        yield return new WaitForSeconds(.3f);
        CongresswomanSelectedSFXAS.Play();
    }
}
