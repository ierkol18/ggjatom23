using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public partial class Animal : MonoBehaviour
{
    public static Action onTween;
    public static void Fire_onTween() { onTween?.Invoke(); }

    // --------------DATA------------------------ 
    [Header("Animal Data")]
    public SpecimenData specimenData;
    [SerializeField] Image image;
    
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
        onTween += tweenAnimalImage;
    }

    void Start()
    {
        image.sprite = specimenData.sprite;
        DOTween.Init(true, true, LogBehaviour.Verbose).SetCapacity(200, 10); // Dotween initialized for the first time to adding bounce effect when clicked.
        _animalRT = GetComponent<RectTransform>(); // Getting the rect transform of the animal sprite.
        currentAnimationClip = specimenData.animationClip;
        OnAnimationChange(currentAnimationClip);

        StartCoroutine(MoveImage());
        //currentAnimationClip = _animator.GetCurrentAnimatorClipInfo(0)[0].clip;
    }
    
    public void OnAnimationChange(AnimationClip anim)
    {
       // if (anim != currentAnimationClip)
        //{
            //currentAnimationClip = anim;
            _animator.Play(anim.name, 0, 0f);
       // }
    }

    public void tweenAnimalImage()
    {
        _animalRT.DOSizeDelta(_tweenSize, _tweenDuration).SetEase(Ease.OutCubic).OnStepComplete(() => _animalRT.DOSizeDelta(_originalSize, _tweenDuration).SetEase(Ease.InCubic));
    }

    private IEnumerator MoveImage()
    {

        while (true)
        {
            int newIntX = UnityEngine.Random.Range(-(int)UICanvas.instance.rectT.rect.width / 3, (int)UICanvas.instance.rectT.rect.width / 3);
            int newIntY = UnityEngine.Random.Range(-(int)UICanvas.instance.rectT.rect.height / 3, (int)UICanvas.instance.rectT.rect.height /3);
            image.rectTransform.DOLocalMove(new Vector2(newIntX, newIntY), 5f);
            yield return new WaitForSeconds(10);
        }
    }
    

    public void DestroyAnimal()
    {
        Destroy(this.gameObject);
    }
}


 

