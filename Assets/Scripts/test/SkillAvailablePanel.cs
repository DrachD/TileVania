using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SkillAvailablePanel : MonoBehaviour
{
    // --------- event Actions ------------------- //
    public event Action<AvailableSlot> OnBeginDragEvent;
    public event Action<AvailableSlot> OnEndDragEvent;
    public event Action<AvailableSlot> OnDragEvent;
    // --------- End event Actions ---------------- //
    // -------------------------------------------- //
    [SerializeField] private SkillAvailablePanel availiableSlot_Parent;
    [SerializeField] private Skill[] skills;
    [SerializeField] private AvailableSlot[] availableSlots;
    private void Start()
    {
        for (int i = 0; i < availableSlots.Length; i++)
        {
            availableSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            availableSlots[i].OnEndDragEvent += OnEndDragEvent;
            availableSlots[i].OnDragEvent += OnDragEvent;
        }
    }
    private void OnValidate()
    {
        availableSlots = availiableSlot_Parent.GetComponentsInChildren<AvailableSlot>();

        int i = 0;
        for (; i < availableSlots.Length && i < skills.Length; i++)
        {
            availableSlots[i].Skill = skills[i];
        }
        for (; i < availableSlots.Length; i++)
        {
            availableSlots[i].Skill = null;
        }
    }
}
