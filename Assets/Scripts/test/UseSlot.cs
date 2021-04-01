using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UseSlot : SkillSlot,
                       IBeginDragHandler,
                       IEndDragHandler,
                       IDragHandler,
                       IDropHandler
{
    public KeyCode key;
    public event Action<UseSlot> OnBeginDragEvent;
    public event Action<UseSlot> OnEndDragEvent;
    public event Action<UseSlot> OnDragEvent;
    public event Action<UseSlot> OnDropEvent;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (OnBeginDragEvent != null)
            OnBeginDragEvent(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (OnEndDragEvent != null)
            OnEndDragEvent(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragEvent != null)
            OnDragEvent(this);   
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (OnDropEvent != null)
            OnDropEvent(this);
    }
}

