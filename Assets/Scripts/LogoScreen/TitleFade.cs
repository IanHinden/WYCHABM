using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleFade : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(NextScene());
    }

    public void FixedUpdate()
    {
        if (Input.anyKey)
        {
            StartCoroutine(FadeOut());
        }
    }


    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
