using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSceneWithAnimation : MonoBehaviour
{
    public Animator transitionAnimator; // Assigne cet Animator dans l'Inspector avec ton animation de transition
    public float transitionTime = 1f; // Temps que prend l'animation avant de charger la nouvelle sc�ne

    // Cette fonction devrait �tre appel�e quand le bouton est cliqu�
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

        // Charge la nouvelle sc�ne
        SceneManager.LoadScene("Start");
    }
}