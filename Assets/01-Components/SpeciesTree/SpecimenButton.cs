using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpecimenButton : MonoBehaviour
{
    private TextMeshProUGUI buttonText;
    [SerializeField] private SpecimenData specimenData;
    private bool isButtonActive = false;
    
    [SerializeField] private Material LockedMaterial;
    [SerializeField] private Material DisabledMaterial;
    [SerializeField] private Material ActivatedMaterial;

    public static Action onSpecimenTextChange;
    public static void Fire_onSpecimenTextChange() { onSpecimenTextChange?.Invoke(); }
    private void Awake()
    {
        buttonText = transform.GetComponentInChildren<TextMeshProUGUI>();
        onSpecimenTextChange += OnSpecimenTextChange;

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
            case SpecimenData.State.Locked:
                buttonText.fontMaterial = LockedMaterial;
                isButtonActive = false;
                break;
            case SpecimenData.State.Unlocked_Disable:
                buttonText.fontMaterial = DisabledMaterial;
                isButtonActive = false;
                break;
            case SpecimenData.State.Unlocked_Active:
                buttonText.fontMaterial = ActivatedMaterial;
                isButtonActive = true;
                break;
        }
    }

}
