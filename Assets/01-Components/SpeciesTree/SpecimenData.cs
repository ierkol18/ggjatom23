using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpecimenData", menuName = "Specimen", order = 0)]

public class SpecimenData : ScriptableObject 
{
    public string specimenName;
    [TextArea] public string description;
    public State specimenState;

    public enum State
    {
        Locked,
        Unlocked_Disable,
        Unlocked_Active
    }
}
