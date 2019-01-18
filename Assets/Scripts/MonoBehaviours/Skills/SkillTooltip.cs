using UnityEngine;
using UnityEngine.UI;

public class SkillTooltip : MonoBehaviour
{
    [SerializeField]
    private Text SkillNameText;
    [SerializeField]
    private Text SkillTypeText;
    [SerializeField]
    private Text SkillDescriptionText;

    private void Awake()
    {
        gameObject.SetActive(false);
    }


    public void ShowTooltip(SkillController skill)
    {
        if (skill != null)
        {
            //SkillNameText.text = skill.SkillDataCopy.SkillName;
            //SkillTypeText.text = skill.SkillDataCopy.SkillType.ToString();
            //SkillDescriptionText.text = skill.SkillDataCopy.SkillDescription;

            gameObject.SetActive(true);
        }
    }

    public void HideTooltip()
    {

        gameObject.SetActive(false);
    }



}
