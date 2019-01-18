using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public SkillType SlotSkillType;

    [SerializeField]
    protected Image icon;
    [SerializeField]
    protected SkillTooltip tooltip;

    [SerializeField]
    private SkillController _skill;
    public SkillController Skill
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
                //icon.sprite = _skill.SkillDataCopy.Icon;
            }
        }
    }

    private void Awake()
    {
        icon = GetComponent<Image>();

        if (_skill == null)
        {
            icon.enabled = false;
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
