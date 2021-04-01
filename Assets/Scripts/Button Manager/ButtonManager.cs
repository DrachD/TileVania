using System;
using UnityEngine;
using System.Collections.Generic;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private InputComponent[] inputComponents;
    public List<string> keyNames;
    public List<KeyCode> keyCodes;
    private void OnValidate()
    {
        RefreshUI();
    }
    public void RefreshUI()
    {
        keyNames.Clear();
        keyCodes.Clear();
        for (int i = 0; i < inputComponents.Length; i++)
        {
            keyNames.Add(inputComponents[i].defaultKeyName);
            keyCodes.Add(inputComponents[i].defaultKeyCode);
        }
    }
}
