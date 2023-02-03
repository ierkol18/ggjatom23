using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimalData", menuName = "Animal", order = 0)]
public class AnimalData : ScriptableObject 
{
    [SerializeField] AnimalData[] nextPossibleAnimalDatas;
    public ObjectsOnClick objectsOnClick_prefab;
    public Sprite sprite;
}
