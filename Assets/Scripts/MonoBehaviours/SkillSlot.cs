using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public SkillTypes SlotSkillType;

    [SerializeField]
    protected Image icon;
    [SerializeField]
    protected SkillTooltip tooltip;

    private Skill _skill;
    public Skill Skill
    {
        get
        {
            return _skill;
        }
        set
        {
            _skill = value;
            if (_skill == null)
            {
                icon.enabled = false;
            }
            else
            {
                icon.sprite = _skill.Icon;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.ShowTooltip(Skill);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideTooltip();
    }
}
