using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerSkills : ScriptableObject
{
    [SerializeField]
    private SkillData[] playerSkillSlots = new SkillData[6];

    public SkillData[] PlayerSkillSlots
    {
        get
        {
            return playerSkillSlots;
        }
        set
        {
            playerSkillSlots = value;
        }
    }

}
