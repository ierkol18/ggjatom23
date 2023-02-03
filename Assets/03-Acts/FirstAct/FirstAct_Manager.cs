using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAct_Manager : MonoBehaviour
{
    public Animation anim;

    [SerializeField] GameObject stageChooserGO;

    private void Start()
    {
        anim = GetComponent<Animation>();
        anim.Play("YourAnimationName");
    }

    public void onAnimatoinEnd()
    {
        stageChooserGO.SetActive(true);
    }
}
