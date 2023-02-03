using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance { get; private set; }

    [SerializeField] AudioSource audioSource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        ToggleMusic();
    }

    public void ToggleMusic()
    {
        if (audioSource.isPlaying)
            audioSource.Stop();
        else
            audioSource.Play();
    }

}
