using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Animal", menuName = "~/Desktop/ggjatom23/Assets/01-Components/Animals/Animal.cs/Animal", order = 0)]
public class AnimalData : ScriptableObject 
{
    public int pointPerClick;
    [SerializeField] Animal animal;
    [SerializeField] Animal[] nextPossibleAnimals;

}
