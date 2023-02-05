using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstAct_Manager2 : MonoBehaviour
{

    [SerializeField] GameObject stageChooserGO;
    [SerializeField] Button playButton;
 

    private void Start()
    {
        playButton.onClick.AddListener(goToGame);
     
    }

    public void goToGame()
    {
        stageChooserGO.SetActive(true);
    }

}
