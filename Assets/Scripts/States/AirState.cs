using UnityEngine;
public class AirState : State
{
    protected bool onRun;
    protected bool onJump;
    protected bool onAir;
#region Input Data
    protected bool jump;
#endregion
    public AirState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }
    public override void Enter() 
    {
        base.Enter();
        forceX = character.GetFloatAnimator(character.MoveHorizontalParam);
        if (Mathf.Abs(forceX) > 0.0f) onRun = true;

        character.SetBoolAnimator(character.SoarParam, true);
    }
    public override void Exit() 
    {
        base.Exit();
        character.SetBoolAnimator(character.SoarParam, false);
    }
    public override void InputHander()
    {   
        base.InputHander();

        forceX = Input.GetAxis("Horizontal");
        jump = Input.GetKeyDown(KeyCode.Space);
        onAttack = Input.GetMouseButtonDown(0);
    }
    public override void Update() 
    {
        base.Update();

        character.SetBoolAnimator(character.AttackParam, onAttack);

        float forceX = Input.GetAxis("Horizontal");

        if (Mathf.Abs(forceX) > 0.0f) 
        {
            onRun = true;
        }
        else 
        {
            onRun = false;
            //forceInt = 0;
        }

        character.SetFloatAnimator(character.MoveHorizontalParam, forceX);
        character.SetBoolAnimator(character.RunParam, onRun);
    }
    public override void FixedUpdate() 
    {
        base.FixedUpdate();
        if (character.OnGround)
        {
            stateMachine.ChangeState(character.standState);
        }
        if (character.OnWall && character.Rigidbody2D.velocity.y < 0.0f)
        {
            if (character.OnEye)
            {
                stateMachine.ChangeState(character.handState);
            }   
            //else
            //{
                //stateMachine.ChangeState(character.climbState);
            //}
        }
        // if (!character.OnEye && character.OnWall)
        // {
        //     stateMachine.ChangeState(character.climbState);
        // }
        // if (character.OnEye && character.OnWall && character.Rigidbody2d.velocity.y < 0.0f)
        // {
        //     stateMachine.ChangeState(character.handState);
        // }
    }
}
