using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadPreviousScene()
    {
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        
        int previousSceneIndex = currentSceneIndex - 1;

        if (previousSceneIndex >= 0)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
        else
        {
            Debug.LogError("There is no previous scene to load.");
        }
    }
}
