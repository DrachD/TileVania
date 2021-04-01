using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SkillUsePanel : MonoBehaviour
{
    // ---------- event Actions ----------- //
    public event Action<UseSlot> OnBeginDragEvent;
    public event Action<UseSlot> OnEndDragEvent;
    public event Action<UseSlot> OnDragEvent;
    public event Action<UseSlot> OnDropEvent;
    // ------------ end event Actions --------//
    [SerializeField] private SkillUsePanel useSlots_parent;
    [SerializeField] private UseSlot[] useSlots;
    private void Start()
    {
        for (int i = 0; i < useSlots.Length; i++)
        {
            useSlots[i].OnDropEvent += OnDropEvent;
            useSlots[i].OnDragEvent += OnDragEvent;
            useSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            useSlots[i].OnEndDragEvent += OnEndDragEvent;
        }
    }
    private void OnValidate()
    {
        useSlots = useSlots_parent.GetComponentsInChildren<UseSlot>();
    }
    public bool CanReciveSlot(AvailableSlot availableSlot)
    {
        for (int i = 0; i < useSlots.Length; i++)
        {
            if (useSlots[i].Skill == availableSlot.Skill)
            {
                useSlots[i].Skill = null;
                return true;
            }
        }

        return true;
    }
}
