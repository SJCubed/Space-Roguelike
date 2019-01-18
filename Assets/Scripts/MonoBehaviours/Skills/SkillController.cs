using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    [SerializeField]
    private PlayerSkills playerSkills;
    private PlayerSkills playerCurrentSkills;

    private SkillCastSnapshot[] snapshots = new SkillCastSnapshot[6];


    private void Awake()
    {

    }

    private void OnEnable()
    {

        playerCurrentSkills = Instantiate(playerSkills);

    }

    private void OnDisable()
    {
        Destroy(playerCurrentSkills);
    }

    protected virtual void Update()
    {
        SkillInput();
    }

    private IEnumerator SkillCoroutine(SkillCastSnapshot snapshot)
    {
        foreach (SkillAction action in snapshot.SkillData.SkillActions)
        {
            yield return StartCoroutine(action.Action(this, snapshot));
        }
    }

    private void SkillInput()
    {
        if (Input.GetButtonDown("Skill1") && playerCurrentSkills.PlayerSkillSlots[0] != null)
        {
            snapshots[0] = new SkillCastSnapshot(gameObject, playerCurrentSkills.PlayerSkillSlots[0]);
            if (CheckCanCast(snapshots[0]))
            {
                StartCoroutine(SkillCoroutine(snapshots[0]));
            }
        }
        if (Input.GetButtonDown("Skill2") && playerCurrentSkills.PlayerSkillSlots[1] != null)
        {
            snapshots[1] = new SkillCastSnapshot(gameObject, playerCurrentSkills.PlayerSkillSlots[1]);
            if (CheckCanCast(snapshots[1]))
            {
                StartCoroutine(SkillCoroutine(snapshots[1]));
            }
        }
        if (Input.GetButtonDown("Skill3") && playerCurrentSkills.PlayerSkillSlots[2] != null)
        {
            snapshots[2] = new SkillCastSnapshot(gameObject, playerCurrentSkills.PlayerSkillSlots[2]);
            if (CheckCanCast(snapshots[2]))
            {
                StartCoroutine(SkillCoroutine(snapshots[2]));
            }
        }
        if (Input.GetButtonDown("UltSkill") && playerCurrentSkills.PlayerSkillSlots[3] != null)
        {
            snapshots[3] = new SkillCastSnapshot(gameObject, playerCurrentSkills.PlayerSkillSlots[3]);
            if (CheckCanCast(snapshots[3]))
            {
                StartCoroutine(SkillCoroutine(snapshots[3]));
            }
        }
        if (Input.GetButtonDown("BasicAttack") && playerCurrentSkills.PlayerSkillSlots[4] != null)
        {
            snapshots[4] = new SkillCastSnapshot(gameObject, playerCurrentSkills.PlayerSkillSlots[4]);
            if (CheckCanCast(snapshots[4]))
            {
                StartCoroutine(SkillCoroutine(snapshots[4]));
            }
        }
        if (Input.GetButtonDown("MovementSkill") && playerCurrentSkills.PlayerSkillSlots[5] != null)
        {
            snapshots[5] = new SkillCastSnapshot(gameObject, playerCurrentSkills.PlayerSkillSlots[5]);
            if (CheckCanCast(snapshots[5]))
            {
                StartCoroutine(SkillCoroutine(snapshots[5]));
            }
        }

    }

    private bool CheckCanCast(SkillCastSnapshot snapshot)
    {

        if (snapshot.SkillData.OnCooldown)
            return false;
        else
            return true;


    }

}
