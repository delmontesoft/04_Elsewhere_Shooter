using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 10f;

    // Called before Start()
    void Awake()
    {
        DontDestroyOnLoad(gameObject);     // this object is not destroyed when loading the next scene
    }

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
            nextSceneIndex = 0;         // go back to the splash screen
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}
