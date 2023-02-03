using UnityEngine;
using UnityEngine.UI;

public class PauseSettings : MonoBehaviour
{
    [SerializeField] Sprite musicOn, musicOff;
    [SerializeField] Button replayButton, musicButton;
  
    void Start()
    {
        musicButton.GetComponent<Image>().sprite = musicOn;
        replayButton.onClick.AddListener(onReplayButton);
        musicButton.onClick.AddListener(onMusicButton);
    }

    void onMusicButton()
    {
        MusicManager.instance.ToggleMusic();
    }

    void onReplayButton()
    {
        //TODO
    }

    
}
