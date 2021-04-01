using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName="Achivement")]
public class Achivement : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;
    public string Name => _name;
    public string Description => description;
    public Sprite Icon => icon;
}
