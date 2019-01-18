using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    BasicAttack = 0,
    MovementSkill = 1,
    BasicSkill = 2,
    UltimateSkill = 3
}

public enum SkillLevel
{
    Crude = 0,
    Normal = 1,
    Refined = 2,
    Perfect = 3
}

public enum TargetPositionType
{
    Player = 0,
    Auto = 1,
    Direction = 2,
    Mouse = 3,
    Unit = 4,
    Coordinate = 5
}

[CreateAssetMenu (menuName = "Skills/SkillData")]
public class SkillData : ScriptableObject
{
    public string SkillName;
    public Sprite Icon;
    public SkillLevel SkillLevel;
    public SkillType SkillType;
    [Space]
    [Multiline]
    public string SkillDescription;
    [Space]
    [HideInInspector]
    public int NumberOfCharges = 1;
    public int MaxCharges = 1;
    [HideInInspector]
    public float CurrentCooldown = 0f;
    public float Cooldown;
    [Space]
    public SkillAction[] SkillActions;

    [HideInInspector]
    public bool OnCooldown = false;
}
