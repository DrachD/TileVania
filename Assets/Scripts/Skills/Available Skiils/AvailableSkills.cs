using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableSkills : MonoBehaviour
{
    public event Action<AvailableSkillSlot> OnBeginDragEvent;
    public event Action<AvailableSkillSlot> OnEndDragEvent;
    public event Action<AvailableSkillSlot> OnDragEvent;
    public event Action<AvailableSkillSlot> OnDropEvent;
    [SerializeField] List<Skill> skills;
    [Space]
    [SerializeField] AvailableSkillSlot[] availableSkillSlots;
    [Space]
    [SerializeField] GameObject availableSkillSlots_prefab;

    private void Awake()
    {
        Init();
        availableSkillSlots = GetComponentsInChildren<AvailableSkillSlot>();
    }
    private void Start()
    {
        for (int i = 0; i < availableSkillSlots.Length; i++)
        {
            availableSkillSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            availableSkillSlots[i].OnEndDragEvent += OnEndDragEvent;
            availableSkillSlots[i].OnDragEvent += OnDragEvent;
            availableSkillSlots[i].OnDropEvent += OnDropEvent;
        }
    }
    private void Init()
    {
        for (int i = 0; i < skills.Count; i++)
        {
            GameObject obj = Instantiate(availableSkillSlots_prefab);
            obj.GetComponent<AvailableSkillSlot>().Skill = skills[i];
            obj.transform.SetParent(gameObject.transform);
        }
    }
    private void OnValidate()
    {
        RefreshUI();
    }
    private void RefreshUI()
    {
        
    }
}
