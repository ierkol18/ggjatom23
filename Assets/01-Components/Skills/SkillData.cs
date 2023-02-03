using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Skill", order = 0)]

public class SkillData : ScriptableObject 
{
    public Sprite sprite;
    public int clickCost;
    public int extraPointPerClick;
    [SerializeField] SkillData[] nextPossibleSkillDatas;

    public enum State
    {
        Locked,
        Unlocked_Bought,
        Unlocked_NotBought
    }
}
