using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaScene : MonoBehaviour
{
    [SerializeField] Animal rootAnimalPrefab;

    void Start()
    {
        Debug.Log("Start");
        GameManager.instance.currentAnimal = rootAnimalPrefab;
        UICanvas.instance.Prepare(GameManager.instance.currentAnimal);
    }

   
}
