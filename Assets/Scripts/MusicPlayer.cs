using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Called before Start()
    void Awake()
    {
        DontDestroyOnLoad(gameObject);     // this object is not destroyed when loading the next scene
    }

}
