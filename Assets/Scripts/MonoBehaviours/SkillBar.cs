using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillBar : MonoBehaviour
{
    [SerializeField]
    private Transform skillBar;
    [SerializeField]
    private SkillSlot[] skillSlots;

    private void OnValidate()
    {
        skillSlots = skillBar.GetComponentsInChildren<SkillSlot>();
    }

    public bool AddSkill(Skill skill, out Skill previousSkill)
    {
        for (int i = 0; i < skillSlots.Length; i++)
        {
            if(skillSlots[i].SlotSkillType == skill.ThisSkillType)
            {
                previousSkill = skillSlots[i].Skill;
                skillSlots[i].Skill = skill;
                return true;
            }
        }
        previousSkill = null;
        return false;
    }

    public bool RemoveSkill(Skill skill)
    {
        for (int i = 0; i < skillSlots.Length; i++)
        {
            if (skillSlots[i].Skill == skill)
            {
                skillSlots[i].Skill = null;
                return true;
            }
        }
        return false;
    }
}
