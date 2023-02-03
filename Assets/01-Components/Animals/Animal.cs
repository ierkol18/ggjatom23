using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{

    [SerializeField] AnimalData animalData;
    [SerializeField] Image image;

    void Start()
    {
        image.sprite = animalData.sprite;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            GameManager.instance.onClick();


    }

}
