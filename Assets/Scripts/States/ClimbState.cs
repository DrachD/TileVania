using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbState : State
{
    private bool touchEye;
    private bool touchHand;
    public ClimbState(Character character, StateMachine stateMachine)
    {
        this.character = character;
        this.stateMachine = stateMachine;
    }
    public override void Enter() 
    {
        base.Enter();
        Debug.Log("climb");
        touchEye = false;
        touchHand = true;
        character.SetBoolAnimator(character.TouchEyeParam, touchEye);
        character.SetBoolAnimator(character.TouchHandParam, touchHand);
    }
    public override void Exit() 
    {
        base.Exit();
        touchEye = false;
        touchHand = false;
        character.SetBoolAnimator(character.TouchEyeParam, touchEye);
        character.SetBoolAnimator(character.TouchHandParam, touchHand);
    }
    public override void InputHander() 
    {
        base.InputHander();        
    }
    public override void Update() 
    {
        base.Update();
        if (character.OnGround)
        {
            stateMachine.ChangeState(character.standState);
        }
    }
    public override void FixedUpdate() 
    {
        base.FixedUpdate();
    }
}
