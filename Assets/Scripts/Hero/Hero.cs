using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private ButtonManager btnManager;
    public List<UseSlot> skillsUsed;
    private float _attackSpeed;
    private float _moveSpeed;
    private float _damage;
    private float _health;
    private Animation _anim;
    public void Execute() { }
    protected virtual void Start() { }
    protected virtual void Update() 
    {
        InputHandler();
    }
    private void InputHandler()
    {
        
        if (Input.GetKeyDown(btnManager.keyCodes[0]))
        {
            Debug.Log("0");
        }
        if (Input.GetKeyDown(btnManager.keyCodes[1]))
        {
            Debug.Log("1");
        }
    }
}
