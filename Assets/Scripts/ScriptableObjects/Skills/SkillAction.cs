using System.Collections;
using UnityEngine;

public abstract class SkillAction : ScriptableObject
{

    public abstract IEnumerator Action(MonoBehaviour skill, SkillCastSnapshot skillCastSnapshot);

}
