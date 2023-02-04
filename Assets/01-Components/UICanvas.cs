using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour
{
    [SerializeField] private PauseSettings ps;
    [SerializeField] private Button pauseButon;
    public RectTransform rectT => transform as RectTransform;
    private Animal currentAnimal;
    public static UICanvas instance { get; private set; }
    public List<Animal> currentAnimalsOnScreen = new List<Animal>();
    bool isDestroying = false;
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
        currentAnimal = animal;
        UICanvas.instance.currentAnimalsOnScreen.Add(GameManager.instance.currentAnimal);
    }

    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos;

            GameManager.instance.onClick();
            StartCoroutine(onObjectClicked());

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(pauseButon.GetComponent<RectTransform>(), Input.mousePosition, null, out mousePos))
            {
                Debug.Log("Market button pressed0");
                Instantiate(ps, UICanvas.instance.rectT);
                GameManager.instance.gameOn = false;
            }
            if (currentAnimal.animalData.neededClickToClone <= GameManager.instance.clickCounter)
            {
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
                else
                {
                    DestroyAll();
                    GameManager.instance.currentAnimal = GameManager.instance.currentAnimal.animalData.nextPossibleAnimalDatas[0].animal;
                    Debug.Log(GameManager.instance.currentAnimal);
                }
            }
        }
       
        tweenAnimalImage();
    }

    private void DestroyAll()
    {
        if(isDestroying == false)
        {
            isDestroying = true;
            for (int i = 0; i < currentAnimalsOnScreen.Count; i++)
                currentAnimalsOnScreen[i].DestroyAnimal();
        }
        
    }

    IEnumerator onObjectClicked()
    {
        ObjectsOnClick ooc = Instantiate(currentAnimal.animalData.objectsOnClick_prefab, rectT);
        Vector2 mousePos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectT, Input.mousePosition, null, out mousePos))
        {
            ooc.gameObject.transform.position = rectT.TransformPoint(mousePos);
        }
        yield return new WaitForSeconds(0.8f);

        Destroy(ooc.gameObject);

    }


    private void tweenAnimalImage()
    {
            
        currentAnimal._animalRT.DOSizeDelta(currentAnimal._tweenSize,currentAnimal. _tweenDuration)
        .SetEase(Ease.OutCubic)
        .OnStepComplete(() => currentAnimal._animalRT.DOSizeDelta(currentAnimal._originalSize, currentAnimal._tweenDuration).SetEase(Ease.InCubic));
    }


}
