using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSceneWithAnimation : MonoBehaviour
{
    public Animator transitionAnimator; // Assigne cet Animator dans l'Inspector avec ton animation de transition
    public float transitionTime = 1f; // Temps que prend l'animation avant de charger la nouvelle scène

    // Cette fonction devrait être appelée quand le bouton est cliqué
    public void LoadNextScene(string sceneName)
    {
        StartCoroutine(TransitionToScene(sceneName));
    }

    IEnumerator TransitionToScene(string sceneName)
    {
        // Joue l'animation de transition
        transitionAnimator.SetTrigger("Start");

        // Attends que l'animation se termine
        yield return new WaitForSeconds(transitionTime);

        // Charge la nouvelle scène
        SceneManager.LoadScene("Start");
    }
}