using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Skill", order = 1)]

public class SkillData : MonoBehaviour
{
    public Sprite sprite;
    public int clickCost;

    public enum State
    {
        Locked,
        Unlocked_Bought,
        Unlocked_NotBought
    }
}
