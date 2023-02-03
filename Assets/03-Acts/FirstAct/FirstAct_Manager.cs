using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAct_Manager : MonoBehaviour
{

    [SerializeField] GameObject stageChooserGO;

    public void onAnimatoinEnd()
    {
        stageChooserGO.SetActive(true);
    }
}
