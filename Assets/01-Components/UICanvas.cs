using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UICanvas : MonoBehaviour
{
    public RectTransform rectT => transform as RectTransform;
    private Animal currentAnimal;
    public static UICanvas instance { get; private set; }
    List<Animal> currentAnimalsOnScreen = new List<Animal>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void Prepare(Animal animal)
    {
        Debug.Log("Prepare");
        currentAnimal = animal;
    }

    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos;

            GameManager.instance.onClick();
            // StartCoroutine(onObjectClicked());
            if (currentAnimal.animalData.neededClickToClone <= GameManager.instance.clickCounter)
            {
                Debug.Log("Girdi");
              
                if(currentAnimalsOnScreen.Count < currentAnimal.animalData.maxInstanceCount)
                {
                    Animal newAnimal = Instantiate(currentAnimal, rectT);
                    GameManager.instance.clickCounter = 0;
                    currentAnimalsOnScreen.Add(newAnimal);
                    if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectT, Input.mousePosition, null, out mousePos))
                    {
                        newAnimal.gameObject.transform.position = rectT.TransformPoint(mousePos);
                    }
                }
               
            }
        }
       

        //tweenAnimalImage();
    }

    
    

}
