using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] SkillData skillData;
    public void BuySkill()
    {
        if(GameManager.instance.clickCounter >= skillData.clickCost)
            GameManager.instance.clickCounter -= skillData.clickCost;
    }
}
