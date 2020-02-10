using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;         // go back to the splash screen (or a win screen)
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

}
