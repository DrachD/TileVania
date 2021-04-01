using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchRunState : GroundState
{
    public CrouchRunState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }
    public override void Enter() 
    {
        base.Enter();
        onRun = true;
        onCrouch = true;
    }
    public override void Exit() 
    {
        base.Exit();
        onRun = false;
        onCrouch = false;
    }
    public override void InputHander()
    {
        base.InputHander();
        
    }
    public override void Update() 
    {
        base.Update();
    }
    public override void FixedUpdate() 
    {
        base.FixedUpdate();
    }
}
