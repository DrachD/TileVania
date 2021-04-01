using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementManager : MonoBehaviour
{
#region Singleton
    public static AchivementManager Instance { get; private set; }
#endregion
    // When our achivement is activated
    public event Action<Achivement> OnActivateAchivementEvent;
    // All achivements data
    [SerializeField] private List<Achivement> achivements;
    private void Awake()
    {
        if (Instance == null) 
            Instance = this;

        GameEvent.Instance.OnDeathEvent += Dead;
        GameEvent.Instance.OnFirstBloodEvent += FirstBlood;
        GameEvent.Instance.OnLowHealthPoint += Health;
    }
    // when my character died
    public void Dead(int id)
    {
        if (id == 0)
        {
            SetDataAchivements(0);
            GameEvent.Instance.OnDeathEvent -= Dead;
        } 
            
    }
    // when my character has first blood
    public void FirstBlood(int id)
    {
        if (id != 0) 
        {
            SetDataAchivements(1);
            GameEvent.Instance.OnFirstBloodEvent -= FirstBlood;
        }
    }
    // when my character has health less than 50
    public void Health(int id, float value)
    {
        if (id == 0 && value < 50f)
        {
            SetDataAchivements(2);
            GameEvent.Instance.OnLowHealthPoint -= Health;
        }
    }
    private void SetDataAchivements(int index)
    {
        OnActivateAchivementEvent?.Invoke(achivements[index]);
    }
}
