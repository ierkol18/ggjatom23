using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Animal : MonoBehaviour, IPointerClickHandler
{

    public AnimalData animalData;
    [SerializeField] Image image;
    [SerializeField] RectTransform rectT;
    // --------------TWEENING-------------------- 
    private Sequence _sizeTween;
    private RectTransform _animalRT;
    [SerializeField] private float _tweenDuration = 0.5f;
    [SerializeField] private Vector2 _tweenSize = new Vector2(600f, 600f);
    [SerializeField] private Vector2 _originalSize = new Vector2(500f, 500f);

    // ------------------------------------------

    void Start()
    {
        image.sprite = animalData.sprite;
        DOTween.Init(true, true, LogBehaviour.Verbose).SetCapacity(200, 10); // Dotween initialized for the first time to adding bounce effect when clicked.
        _animalRT = GetComponent<RectTransform>(); // Getting the rect transform of the animal sprite.
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerEnter == this.gameObject)
        {
            GameManager.instance.onClick();
            StartCoroutine(onObjectClicked());
        }
        tweenAnimalImage();
    }

    IEnumerator onObjectClicked()
    {
        ObjectsOnClick ooc = Instantiate(animalData.objectsOnClick_prefab, transform);
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
        _animalRT.DOSizeDelta(_tweenSize, _tweenDuration)
            .SetEase(Ease.OutCubic)
            .OnStepComplete(() => _animalRT.DOSizeDelta(_originalSize, _tweenDuration).SetEase(Ease.InCubic));
        
        //    .SetLoops(1, LoopType.Yoyo);
    }

}
