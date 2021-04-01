using System;
using UnityEngine;

public class UseSkillsPanel : MonoBehaviour
{
    public event Action<AvailableSkillSlot> OnBeginDragEvent;
    public event Action<AvailableSkillSlot> OnEndDragEvent;
    public event Action<AvailableSkillSlot> OnDragEvent;
    public event Action<AvailableSkillSlot> OnDropEvent;
    public SkillUseSlot[] skillUseSlots;
    private void OnValidate()
    {
        RefreshUI();
    }
    private void RefreshUI()
    {
        skillUseSlots = this.GetComponentsInChildren<SkillUseSlot>();
    }
    private void Awake()
    {
        for (int i = 0; i < skillUseSlots.Length; i++)
        {
            skillUseSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            skillUseSlots[i].OnEndDragEvent += OnEndDragEvent;
            skillUseSlots[i].OnDragEvent += OnDragEvent;
            skillUseSlots[i].OnDropEvent += OnDropEvent;
        }
    }
}
