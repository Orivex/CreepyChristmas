using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    void Awake()
    {
        Instance = this;
    }

    [SerializeField] Animator animator;

    public void ReloadScene()
    {
        StartCoroutine(ReloadSceneEnum());
    }

    IEnumerator ReloadSceneEnum()
    {
        animator.SetTrigger("fade");

        yield return new WaitForSeconds(3.5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
}
