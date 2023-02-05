using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SeaScene : MonoBehaviour
{
    [SerializeField] Animal rootAnimalPrefab;
   


    void Start()
    {

        GameManager.instance.currentAnimal = rootAnimalPrefab;
        UICanvas.instance.Prepare(GameManager.instance.currentAnimal);
    }
    
    private void OpenMarket()
    {
        
    }

}
