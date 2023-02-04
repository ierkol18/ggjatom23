using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public partial class Animal : MonoBehaviour
{
    // --------------DATA------------------------ 
    [Header("Animal Data")]
    public AnimalData animalData;
    [SerializeField] Image image;
    [SerializeField] RectTransform rectT;
    // --------------TWEENING-------------------- 
    [Header("Animal Tweening")]
    private Sequence _sizeTween;
    public RectTransform _animalRT;
    [SerializeField] public float _tweenDuration = 0.5f;
    [SerializeField] public Vector2 _tweenSize = new Vector2(600f, 600f);
    [SerializeField] public Vector2 _originalSize = new Vector2(500f, 500f);
    // --------------ANIMATION-------------------
    [Header("Animal Animation Settings")]
    [SerializeField] private float _animationSpeed = .25f;
    private Animator _animator;
    private AnimationClip currentAnimationClip;
    public static Action<AnimationClip> onAnimationChange;
    // ------------------------------------------
    public static void Fire_onAnimationChange(AnimationClip anim) { onAnimationChange?.Invoke(anim); }
    
    private void Awake()
    {
        _animator = transform.GetComponent<Animator>();
        _animator.speed = _animationSpeed;
        onAnimationChange += OnAnimationChange;
    }

    void Start()
    {
        image.sprite = animalData.sprite;
        DOTween.Init(true, true, LogBehaviour.Verbose).SetCapacity(200, 10); // Dotween initialized for the first time to adding bounce effect when clicked.
        _animalRT = GetComponent<RectTransform>(); // Getting the rect transform of the animal sprite.

        //currentAnimationClip = _animator.GetCurrentAnimatorClipInfo(0)[0].clip;
    }
    
    public void OnAnimationChange(AnimationClip anim)
    {
        if (anim != currentAnimationClip)
        {
            currentAnimationClip = anim;
            _animator.Play(anim.name, 0, 0f);
        }
    }

/*
    public void OnPointerClick(PointerEventData eventData)
    {
    
        GameManager.instance.onClick();
        StartCoroutine(onObjectClicked());
    
        if(animalData.neededClickToClone == GameManager.instance.clickCounter)
        {
            Animal newAnimal = Instantiate(this, rectT);
        }
        
        tweenAnimalImage();
    }
*/
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
    }

}
