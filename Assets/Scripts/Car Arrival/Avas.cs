using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avas : MonoBehaviour
{
    private GameObject Ava1;
    private GameObject Ava2;

    [SerializeField] GameObject shadows;
    private GameObject shadow1;
    private GameObject shadow2;
    void Awake()
    {
        Ava1 = transform.GetChild(0).gameObject;
        Ava2 = transform.GetChild(1).gameObject;

        shadow1 = shadows.transform.GetChild(0).gameObject;
        shadow2 = shadows.transform.GetChild(1).gameObject;
    }

    public IEnumerator Sway()
    {
        yield return new WaitForSeconds(.6f);
        Ava1.SetActive(true);
        shadow1.SetActive(true);
        yield return new WaitForSeconds(.7f);
        Swap();
        yield return new WaitForSeconds(.3f);
        Swap();
        yield return new WaitForSeconds(.3f);
        Swap();
        yield return new WaitForSeconds(.3f);
        Swap();
        yield return new WaitForSeconds(.3f);
        Swap();
        yield return new WaitForSeconds(.3f);
        Swap();
        yield return new WaitForSeconds(.3f);
        Swap();
        yield return new WaitForSeconds(.3f);
        Swap();
        yield return new WaitForSeconds(.3f);
    }

    private void Swap()
    {
        Ava1.SetActive(!Ava1.activeSelf);
        Ava2.SetActive(!Ava2.activeSelf);
        shadow1.SetActive(!shadow1.activeSelf);
        shadow2.SetActive(!shadow2.activeSelf);
    }

    public void Reset()
    {
        this.gameObject.transform.localScale = new Vector3(.7f, .7f, 1);
        shadows.transform.localScale = new Vector3(1, 1, 1);

        Ava1.SetActive(false);
        Ava2.SetActive(false);
        shadow1.SetActive(false);
        shadow2.SetActive(false);
    }
}