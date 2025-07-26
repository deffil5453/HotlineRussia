using UnityEngine;

public class MusicManagerScripts : MonoBehaviour
{
    public MusicManagerScripts Instance;
    public AudioSource AudioSource;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
