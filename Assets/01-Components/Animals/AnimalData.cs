using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimalData", menuName = "Animal", order = 0)]
public class AnimalData : ScriptableObject 
{
    public AnimalData[] nextPossibleAnimalDatas;
    public Animal animal;
    public ObjectsOnClick objectsOnClick_prefab;
    public Sprite sprite;

    public AnimationClip animationClip;

    public int maxInstanceCount;
    public int neededClickToClone;
}
