using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleFade : MonoBehaviour
{
    Animator animator;

    private NextScene nextScene;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        nextScene = new NextScene();
        nextScene.FadeOut.Change.performed += x => TestFunc();

        StartCoroutine(NextScene());
    }

    private void TestFunc()
    {
        Debug.Log("Hey");
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
