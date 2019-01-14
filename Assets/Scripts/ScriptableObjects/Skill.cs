using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SkillTypes
{
    BasicAttack,
    MovementSkill,
    BasicSkill,
    UltimateSkill
}

[CreateAssetMenu]
public class Skill : ScriptableObject
{
    public string SkillName;
    public Sprite Icon;
    public SkillTypes ThisSkillType;
    public bool IsActive = true;
    [Space]
    [Multiline]
    public string SkillDescription;
    [Space]
    public List<SkillSequence> SkillSequences;
}
