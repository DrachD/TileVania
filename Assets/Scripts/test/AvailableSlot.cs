using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AvailableSlot : SkillSlot,
                             IBeginDragHandler,
                             IEndDragHandler,
                             IDragHandler
{
    public event Action<AvailableSlot> OnBeginDragEvent;
    public event Action<AvailableSlot> OnEndDragEvent;
    public event Action<AvailableSlot> OnDragEvent;
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
}
