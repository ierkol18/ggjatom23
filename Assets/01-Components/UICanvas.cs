using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour
{
    [SerializeField] private PauseSettings ps;
    [SerializeField] private Button marketButton;
    [SerializeField] private GameObject marketUI;
    [SerializeField] private TextMeshProUGUI scoreTMP;
    
    public RectTransform rectT => transform as RectTransform;
    private Animal currentAnimal;
    public static UICanvas instance { get; private set; }
    public List<Animal> currentAnimalsOnScreen;
    public bool isDestroying = false, isHoldingMarketButton = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
        marketButton.onClick.AddListener(() =>
        {
            marketUI.SetActive(true);
            
            foreach (Animal animal in currentAnimalsOnScreen)
                animal.gameObject.SetActive(false);

            GameManager.instance.gameOn = false;
            isHoldingMarketButton = true;
        });
        

    }

    public void Prepare(Animal animal)
    {
        currentAnimal = animal;
        currentAnimalsOnScreen.Add(GameManager.instance.currentAnimal);
    }

    public void LateUpdate()
    {
        if(Input.GetMouseButtonUp(0) && !isHoldingMarketButton)
        {
           
            Vector2 mousePos;
            GameManager.instance.onClick();
            StartCoroutine(onObjectClicked());

            if (GameManager.instance.currentAnimal.specimenData.neededClickToClone <= GameManager.instance.clickCounter)
            {
                

                if (currentAnimalsOnScreen.Count < GameManager.instance.currentAnimal.specimenData.maxInstanceCount)
                {
                    Animal newAnimal = Instantiate(GameManager.instance.currentAnimal, rectT);
                    GameManager.instance.clickCounter = 0;
                    currentAnimalsOnScreen.Add(newAnimal);
                    Debug.Log(currentAnimalsOnScreen.Count);
                    if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectT, Input.mousePosition, null, out mousePos))
                    {
                        newAnimal.gameObject.transform.position = rectT.TransformPoint(mousePos);
                    }
                }
   
            }
        }
       
        Animal.Fire_onTween();
        scoreTMP.text = GameManager.instance.clickCounter.ToString();

    }


    public void DestroyAll()
    {
        for (int i = 0; i < currentAnimalsOnScreen.Count; i++)
            currentAnimalsOnScreen[i].DestroyAnimal();
            
        currentAnimalsOnScreen.Clear();
       
        
    }

    IEnumerator onObjectClicked()
    {
        ObjectsOnClick ooc = Instantiate(currentAnimal.specimenData.objectsOnClick_prefab, rectT);
        Vector2 mousePos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectT, Input.mousePosition, null, out mousePos))
        {
            ooc.gameObject.transform.position = rectT.TransformPoint(mousePos);
        }
        yield return new WaitForSeconds(0.8f);

        Destroy(ooc.gameObject);

    }


   

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }
}
