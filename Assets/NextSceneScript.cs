using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneScript : MonoBehaviour
{
    public void LoadNextScene()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;


        int NextSceneIndex = currentSceneIndex + 1;

        if (NextSceneIndex >= 0)
        {
            SceneManager.LoadScene(NextSceneIndex);
        }
        else
        {
            Debug.LogError("There is no previous scene to load.");
        }
    }
}
