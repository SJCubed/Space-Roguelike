using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "SkillActions/SetTarget")]
public class SetTarget : SkillAction
{
    enum TargetType
    {
        Self,
        Auto,
        Direction,
        Ground,
        Unit
    }

    [SerializeField]
    private TargetType targetType;
}
