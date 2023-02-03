using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ObjectsOnClick : MonoBehaviour
{
   [SerializeField] Image image;
   [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        image.sprite = GameManager.instance.currentAnimal.animalData.sprite;
        text.text = GameManager.instance.pointPerClick.ToString();
    }

}
