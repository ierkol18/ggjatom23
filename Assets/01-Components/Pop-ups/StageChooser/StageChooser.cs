using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageChooser : MonoBehaviour
{
    [SerializeField] Button seaButton, landButton;
    
    void Start()
    {
        seaButton.onClick.AddListener(OpenSeaScene);
        landButton.onClick.AddListener(OpenLandScene);
    }

    private void OpenSeaScene()
    {
        Debug.Log("Girdi");
        SceneManager.LoadSceneAsync(sceneName: "SeaScene");
    }

    private void OpenLandScene()
    {
        SceneManager.LoadSceneAsync("LandScene");
        GameManager.instance.gameOn = true;
    }
}
