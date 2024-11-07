using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    AudioSource audioSource;

    void Awake()
    {
        animator.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadSceneAsync(sceneName);

        Player.Instance.transform.position = new(0, -3.5f);

        yield return new WaitForSeconds(1);
        OnTransitionEnd();
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
        animator.enabled = true;
        audioSource.Play();
        animator.SetTrigger("endTransition");
    }

    public void OnTransitionEnd()
    {
        animator.enabled = false;
        audioSource.Stop();
    }
}