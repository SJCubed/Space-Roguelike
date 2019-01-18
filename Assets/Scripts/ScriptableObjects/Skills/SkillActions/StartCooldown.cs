using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StartCooldown : SkillAction
{

    public override IEnumerator Action(MonoBehaviour skill, SkillCastSnapshot snapshot)
    {



        snapshot.SkillData.CurrentCooldown = snapshot.SkillData.Cooldown;
        snapshot.SkillData.OnCooldown = true;
        Debug.Log("Start cooldown");

        skill.StartCoroutine(Cooldown(snapshot));

        yield return null;
    }

    private IEnumerator Cooldown(SkillCastSnapshot snapshot)
    {

        while (snapshot.SkillData.CurrentCooldown > 0)
        {
            snapshot.SkillData.CurrentCooldown -= Time.deltaTime;

            yield return null;
        }
        snapshot.SkillData.OnCooldown = false;
        Debug.Log("Finished cooldown");
    }

}
