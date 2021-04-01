using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AvailableSkillSlot : MonoBehaviour,
                                  IBeginDragHandler,
                                  IEndDragHandler,
                                  IDragHandler,
                                  IDropHandler
{
    public event Action<AvailableSkillSlot> OnBeginDragEvent;
    public event Action<AvailableSkillSlot> OnEndDragEvent;
    public event Action<AvailableSkillSlot> OnDragEvent;
    public event Action<AvailableSkillSlot> OnDropEvent;
    [SerializeField] private Image image;
    private Skill _skill;
    public Skill Skill
    {
        get => _skill;
        set
        {
            _skill = value;
            if (_skill == null) { image.enabled = false; }
            else
            {
                image.sprite = _skill.Icon;
                image.enabled = true;
            }
        }
    }
    private void OnValidate()
    {
        if (image == null)
            image = GetComponent<Image>();
    }
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
