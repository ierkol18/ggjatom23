using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimalData", menuName = "Animal", order = 0)]
public class AnimalData : ScriptableObject 
{
    public int pointPerClick;
    [SerializeField] AnimalData[] nextPossibleAnimalDatas;
    public Sprite sprite;
}
