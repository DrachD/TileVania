using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public void SetMaxHealth(float health) => slider.maxValue = health;
    public void SetInitialHealth(float health)
    {
        if (health <= 0)
        {
            slider.value = 0;
        }
        else if (health >= slider.maxValue)
        {
            slider.value = slider.maxValue;
        } 
        else 
        {
            slider.value = health;
        }
    }
    public void SetHealth(float health) => slider.value = health;
}
