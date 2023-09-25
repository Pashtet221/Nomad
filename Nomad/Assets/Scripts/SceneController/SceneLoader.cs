using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string nextSceneName; // The name of the scene to transition to.

    private float transitionDelay = 2.0f; // Delay before transitioning to the next scene.

    void Start()
    {
        // Invoke the LoadNextScene function after the specified delay.
        Invoke("LoadNextScene", transitionDelay);
    }

    void LoadNextScene()
    {
        // Load the next scene by name.
        SceneManager.LoadScene(nextSceneName);
    }
}
