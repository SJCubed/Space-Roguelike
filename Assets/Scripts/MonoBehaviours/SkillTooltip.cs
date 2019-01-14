using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTooltip : MonoBehaviour
{
    [SerializeField]
    Text SkillNameText;
    [SerializeField]
    Text SkillTypeText;
    [SerializeField]
    Text SkillDescriptionText;

    public void ShowTooltip(Skill skill)
    {
        SkillNameText.text = skill.SkillName;
        SkillTypeText.text = skill.ThisSkillType.ToString();
        SkillDescriptionText.text = skill.SkillDescription;

        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {

        gameObject.SetActive(false);
    }



}
