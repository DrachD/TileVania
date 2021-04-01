using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private SkillAvailablePanel skillAvailablePanel;
    [SerializeField] private SkillUsePanel skillUsePanel;
    [SerializeField] private Image draggableSlot;
    private SkillSlot draggedSlot;
    [SerializeField] private GameObject prefabHero;
    private Hero hero;
    private void Awake()
    {
        GameObject obj = Instantiate(prefabHero, transform.position, Quaternion.identity);
        hero = obj.GetComponent<Hero>();
        // --------- subscribes Available Slot ----------//
        skillAvailablePanel.OnBeginDragEvent += OnBeginDragAvailableSlot;
        skillAvailablePanel.OnEndDragEvent += OnEndDragAvailableSlot;
        skillAvailablePanel.OnDragEvent += OnDragAvailableSlot;
        // ----------------------------------------------//

        // ---------- subscribes Use Slot --------------//
        skillUsePanel.OnDragEvent += OnDragUseSlot;
        skillUsePanel.OnDropEvent += OnDropUseSlot;
        skillUsePanel.OnBeginDragEvent += OnBeginDragUseSlot;
        skillUsePanel.OnEndDragEvent += OnEndDragUseSlot;
        // ----------------------------------------------//
    }
    // ---------------- Available Slot Methods manipulation -----------//
    private void OnBeginDragAvailableSlot(AvailableSlot beginDragSlot)
    {
        if (beginDragSlot.Skill != null)
        {
            draggedSlot = beginDragSlot;
            draggableSlot.sprite = beginDragSlot.Skill.Icon;
            draggableSlot.transform.position = Input.mousePosition;
            draggableSlot.enabled = true;
        }
    }
    private void OnEndDragAvailableSlot(AvailableSlot endDragSlot)
    {
        draggedSlot = null;
        draggableSlot.enabled = false;
    }
    private void OnDragAvailableSlot(AvailableSlot dragSlot)
    {
        if (draggableSlot.enabled)
            draggableSlot.transform.position = Input.mousePosition;
    }
    // ----------------- End Available Slot Method manipulation ----------//

    // ----------------- Use Slot Method manipulation ------------------//
    private void OnBeginDragUseSlot(UseSlot beginDragSlot)
    {
        if (beginDragSlot.Skill != null)
        {
            draggedSlot = beginDragSlot;
            draggableSlot.transform.position = Input.mousePosition;
            draggableSlot.sprite = beginDragSlot.Skill.Icon;
            draggableSlot.enabled = true;
        }
    }
    private void OnEndDragUseSlot(UseSlot endDragSlot)
    {
        draggedSlot = null;
        draggableSlot.enabled = false;
    }
    private void OnDragUseSlot(UseSlot dragSlot)
    {
        if (draggableSlot.enabled)
        {
            draggableSlot.transform.position = Input.mousePosition;
        }
    }
    private void OnDropUseSlot(UseSlot dropSlot)
    {
        if (draggedSlot != null)
        {
            if (draggedSlot is UseSlot)
            {
                Skill tempSkill = dropSlot.Skill;
                dropSlot.Skill = draggedSlot.Skill;
                draggedSlot.Skill = tempSkill;
            }

            if ((draggedSlot is AvailableSlot) && skillUsePanel.CanReciveSlot((AvailableSlot)draggedSlot))
            {
                dropSlot.Skill = draggedSlot.Skill;
                //hero.skillsUsed.Add(dropSlot.Skill);
            }
        }
    }
    // ----------------- End Use Slot Method manipulatoin --------------//
}
