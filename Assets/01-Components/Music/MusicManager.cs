using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance { get; private set; }

    [SerializeField] AudioSource audioSource;
    [SerializeField] Image musicOnImage, musicOffImage;

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
        musicOnImage.gameObject.SetActive(true);
        ToggleMusic();
    }

    public void ToggleMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            musicOnImage.gameObject.SetActive(false);
            musicOffImage.gameObject.SetActive(true);
        }
        else
        {
            audioSource.Play();
            musicOffImage.gameObject.SetActive(false);
            musicOnImage.gameObject.SetActive(true);
        }
    }

}
