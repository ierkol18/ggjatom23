using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstAct_Manager : MonoBehaviour
{

    [SerializeField] GameObject stageChooserGO;
    [SerializeField] Button playButton;
    [SerializeField] Animator animator;

    private void Start()
    {
        playButton.onClick.AddListener(onPlayButton);
        animator.enabled = false;
    }

    public void onPlayButton()
    {
        animator.enabled = true;
    }

    public void onAnimationEnd()
    {
        stageChooserGO.SetActive(true);
    }
}
