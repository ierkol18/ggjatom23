using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAct_Manager : MonoBehaviour
{

    [SerializeField] GameObject stageChooserGO;

    private void Start()
    {
   
    }

    public void onAnimationEnd()
    {
        stageChooserGO.SetActive(true);
    }
}
