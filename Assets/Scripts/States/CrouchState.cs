using UnityEngine;
public class CrouchState : GroundState
{
    public CrouchState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }
    public override void Enter() 
    {
        base.Enter();
        onCrouch = true;
        character.SetBoolAnimator(character.CrouchParam, onCrouch);
    }
    public override void Exit() 
    {
        base.Exit();
        onCrouch = false;
        character.SetBoolAnimator(character.CrouchParam, onCrouch);
    }
    public override void InputHander()
    {
        base.InputHander();
    }
    public override void Update() 
    {
        base.Update();
        
        if (jump)
        {
            onJump = true;
            onCrouch = false;

            character.Jump();

            character.SetBoolAnimator(character.CrouchParam, onCrouch);
            character.SetBoolAnimator(character.JumpParam, onJump);
        }

        if (crouch)
        {
            stateMachine.ChangeState(character.standState);
        }
    }

    public override void FixedUpdate() 
    {
        base.FixedUpdate();
    }
}
