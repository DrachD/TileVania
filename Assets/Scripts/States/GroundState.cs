using UnityEngine;

public class GroundState : State
{
    protected bool onStand;
    protected bool onCrouch;
    protected bool onJump;
    protected bool onRun;
#region Input Data
    protected bool jump;
    protected bool crouch;
#endregion
    public GroundState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }
    public override void Enter() 
    {
        base.Enter();
        onJump = false;
        forceX = character.GetFloatAnimator(character.MoveHorizontalParam);
        if (Mathf.Abs(forceX) > 0.0f) onRun = true;
    }
    public override void Exit() 
    {
        base.Exit();
    }
    public override void InputHander()
    {
        base.InputHander();

        jump = Input.GetKeyDown(KeyCode.Space);
        crouch = Input.GetKeyDown(KeyCode.S);
        forceX = Input.GetAxis("Horizontal");
    }
    public override void Update() 
    {
        base.Update();

        if (Mathf.Abs(forceX) > 0.0f) 
        {
            onRun = true;
        }
        else 
        {
            onRun = false;
        }
        
        character.SetFloatAnimator(character.MoveHorizontalParam, forceX);
        character.SetBoolAnimator(character.RunParam, onRun);
    }
    public override void FixedUpdate() 
    {
        base.FixedUpdate();
        //if (!character.OnGround && onJump)
        //{
        //    stateMachine.ChangeState(character.jumpState);
        //}

        if (!character.OnGround)
        {
            stateMachine.ChangeState(character.jumpState);
        }
    }
}
