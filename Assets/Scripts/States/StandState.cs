using UnityEngine;
public class StandState : GroundState
{
    public StandState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }
    public override void Enter() 
    {
        base.Enter();
        onStand = true;

        character.SetBoolAnimator(character.StandParam, onStand);
        character.SetBoolAnimator(character.RunParam, onRun);
    }
    public override void Exit() 
    {
        base.Exit();
        onStand = false;
        character.SetBoolAnimator(character.StandParam, onStand);
    }
    public override void InputHander()
    {
        base.InputHander();
        onAttack = Input.GetMouseButtonDown(0);
    }
    public override void Update() 
    {
        base.Update();

        character.SetBoolAnimator(character.AttackParam, onAttack);

        if (crouch)
        {
            stateMachine.ChangeState(character.crouchState);
        }

        if (jump)
        {
            character.Jump();
            stateMachine.ChangeState(character.jumpState);
        }
    }
    public override void FixedUpdate() 
    {
        base.FixedUpdate();
    }
}
