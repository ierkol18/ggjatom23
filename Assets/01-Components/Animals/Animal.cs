using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{

    [SerializeField] AnimalData animalData;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.instance.clickCounter += animalData.pointPerClick;
            Debug.Log(GameManager.instance.clickCounter);
        }

    }

}
