using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanel : MonoBehaviour
{
    [SerializeField] private UseSkillsPanel useSkillsPanel;
    [SerializeField] private AvailableSkills availableSkills; 
    [SerializeField] Image draggableSkill;
    private AvailableSkillSlot draggedSkillSlot;
    private void Awake()
    {
        // Begin Drag
        useSkillsPanel.OnBeginDragEvent += BeginDrag;
        availableSkills.OnBeginDragEvent += BeginDrag;
        // End Drag
        useSkillsPanel.OnEndDragEvent += EndDrag;
        availableSkills.OnEndDragEvent += EndDrag;
        // Drag
        useSkillsPanel.OnDragEvent += Drag;
        availableSkills.OnDragEvent += Drag;
        // Drop
        useSkillsPanel.OnDropEvent += Drop;
        availableSkills.OnDropEvent += Drop;
    }
    private void BeginDrag(AvailableSkillSlot availableSkillSlot)
    {
        if (availableSkillSlot.Skill != null)
        {
            draggedSkillSlot = availableSkillSlot;
            draggableSkill.sprite = availableSkillSlot.Skill.Icon;
            draggableSkill.transform.position = Input.mousePosition;
            draggableSkill.enabled = true;
        }
    }
    private void EndDrag(AvailableSkillSlot availableSkillSlot)
    {
        draggedSkillSlot = null;
        draggableSkill.enabled = false;
    }
    private void Drag(AvailableSkillSlot availableSkillSlot)
    {
        if (draggableSkill.enabled)
        {
            draggableSkill.transform.position = Input.mousePosition;
        }
    }
    private void Drop(AvailableSkillSlot availableSkillSlot)
    {
        if (availableSkillSlot is SkillUseSlot)
        {
            SkillUseSlot skillUseSlot = availableSkillSlot as SkillUseSlot;
            if (skillUseSlot.CanReceiveItem(draggedSkillSlot.Skill))
            {
                Skill tempSkill = skillUseSlot.Skill;
                skillUseSlot.Skill = draggedSkillSlot.Skill;
                draggedSkillSlot.Skill = tempSkill;

            }
        }
    }
}
