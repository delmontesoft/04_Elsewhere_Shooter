using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Called before Start()
    void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);     // this object is not destroyed when loading the next scene
        }
    }
}
