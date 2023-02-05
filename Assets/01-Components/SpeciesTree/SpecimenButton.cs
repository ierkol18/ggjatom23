using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpecimenButton : MonoBehaviour
{
    private Button specimenButton;
    private TextMeshProUGUI buttonText;
    [SerializeField] private SpecimenData specimenData;
    private string message = "";
    private bool isButtonClicked = false;

    [SerializeField] private Material LockedMaterial;
    [SerializeField] private Material DisabledMaterial;
    [SerializeField] private Material ActivatedMaterial;

    [SerializeField] private Image roseImage;
    [SerializeField] private Sprite roseBought;
    [SerializeField] private Sprite roseBuyable;
    [SerializeField] private Sprite roseLocked;

    public static Action onSpecimenTextChange;
    public static void Fire_onSpecimenTextChange() { onSpecimenTextChange?.Invoke(); }
    private void Awake()
    {
        specimenButton = GetComponent<Button>();
        
        buttonText = transform.GetComponentInChildren<TextMeshProUGUI>();
        
        onSpecimenTextChange += OnSpecimenTextChange;
        specimenButton.onClick.AddListener(OnButtonClicked);

        buttonText.text = specimenData.specimenName; 
    }

    private void Start()
    {
        onSpecimenTextChange();
    }
    public void OnSpecimenTextChange()
    {
        switch (specimenData.specimenState)
        {
            case SpecimenData.State.LOCKED:
                buttonText.fontMaterial = LockedMaterial;
                roseImage.sprite = roseLocked;
                break;
            case SpecimenData.State.UNLOCKED_DISABLE:
                buttonText.fontMaterial = DisabledMaterial;
                roseImage.sprite = roseBuyable;
                break;
            case SpecimenData.State.UNLOCKED_ACTIVE:
                buttonText.fontMaterial = ActivatedMaterial;
                roseImage.sprite = roseBought;
                break;
        }
    }

    private void Update()
    {
        if (isButtonClicked)
        {
            isButtonClicked = false;
            onSpecimenTextChange();
        }
    }

    private void OnButtonClicked()
    {
        switch (specimenData.specimenState)
        {
            case SpecimenData.State.LOCKED:
                message = "Unfortunately you cannot reach this specimen!";
                ShowErrorMessage(message);
                break;
            case SpecimenData.State.UNLOCKED_DISABLE:
                SelectSpecimen();
                break;
            case SpecimenData.State.UNLOCKED_ACTIVE:
                message = "You have already reached this specimen!";
                ShowErrorMessage(message);
                break;
        }
    }

    private void ShowErrorMessage(string msg){
        Debug.Log(msg);
    }

    private void SelectSpecimen()
    {
        specimenData.specimenState = SpecimenData.State.UNLOCKED_ACTIVE;
        UICanvas.instance.DestroyAll();
        GameManager.instance.currentAnimal = specimenData.animal;
        foreach (var child in specimenData.childSpecimens)
        {
            child.specimenState = SpecimenData.State.UNLOCKED_DISABLE;
       
        }
        foreach (var sibling in specimenData.siblingSpecimens)
        {
            if(sibling is not null)
                sibling.specimenState = SpecimenData.State.LOCKED;
        }
        
      
        isButtonClicked = true;
    }


}
