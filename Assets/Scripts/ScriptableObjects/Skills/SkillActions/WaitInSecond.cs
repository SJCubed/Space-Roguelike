using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WaitInSecond : SkillAction
{
    public float seconds;

    public override IEnumerator Action(MonoBehaviour skill, SkillCastSnapshot skillCastSnapshot)
    {
        Debug.Log("Start waiting");

        yield return new WaitForSeconds(seconds);

        Debug.Log("Finish waiting");

    }
}
