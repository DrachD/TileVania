using System;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public static GameEvent Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null) return;
        Instance = this;
    }
    // When our character or enemy on changed health
    public event Action<int, float> OnHealthChanged;
    public void ChangeHealth(int id, float health)
    {
        OnHealthChanged?.Invoke(id, health);
    }
    // when character get the item
    public event Action<Item> OnUnequipItemEvent;
    public void UnequipItem(Item item)
    {
        OnUnequipItemEvent?.Invoke(item);
    }
    public event Action<Item> OnGetItemEvent;
    public void SetItemFromEquipmentPanel(Item item)
    {
        OnGetItemEvent?.Invoke(item);
    }
#region Interaction with achivements 
    // When my character has first blood on the hands
    public event Action<int> OnFirstBloodEvent;
    public void FirstBlood(int id)
    {
        OnFirstBloodEvent?.Invoke(id);
    }
    // When my character on low hp
    public event Action<int, float> OnLowHealthPoint;
    public void LowHealthPoint(int id, float health)
    {
        OnLowHealthPoint?.Invoke(id, health);
    }
    // When Character Death or Enemy
    public event Action<int> OnDeathEvent;
    public void Death(int id)
    {
        OnDeathEvent?.Invoke(id);
    }
#endregion
    //  Doorway Trigger Enter
    public event Action<int> OnDoorwayTriggerEnter;
    public void DoorwayTriggerEnter(int id)
    {
        OnDoorwayTriggerEnter?.Invoke(id);
    }
    
    // Doorway Trigger Exit
    public event Action<int> OnDoorwayTriggerExit;
    public void DoorwayTriggerExit(int id)
    {
        OnDoorwayTriggerExit?.Invoke(id);
    }
}
