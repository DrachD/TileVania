using UnityEngine;
public class JumpState : AirState
{
    public JumpState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }
    public override void Enter() 
    {
        base.Enter();
        onJump = true;
        onAir = true;

        //character.SetBoolAnimator(character.RunParam, onRun);

        character.SetBoolAnimator(character.JumpParam, onJump);

        //character.SetBoolAnimator(character.SoarParam, true);
        //character.SetBoolAnimator(character.JumpParam, false);
    }
    public override void Exit() 
    {
        base.Exit();
        onJump = false;

        character.SetBoolAnimator(character.JumpParam, onJump);
        //character.SetBoolAnimator(character.SoarParam, onJump);
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
