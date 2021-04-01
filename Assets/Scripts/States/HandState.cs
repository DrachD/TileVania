using UnityEngine;
public class HandState : State
{
    private bool touchEye;
    private bool touchHand;
    private bool jump;
    private bool onRun;
    public HandState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }
    public override void Enter() 
    {
        base.Enter();
        touchEye = true;
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
        jump = Input.GetKeyDown(KeyCode.Space);
        forceX = Input.GetAxis("Horizontal");
    }
    public override void Update() 
    {
        base.Update();
        //float forceX = Input.GetAxis("Horizontal");

        //if (Mathf.Abs(forceX) > 0.0f) 
        //{
        //    onRun = true;
        //}
        //else 
        //    onRun = false;

        //character.SetFloatAnimator(character.MoveHorizontalParam, forceX);

        if (jump)
        {
            character.WallJump();
        }
    }
    public override void FixedUpdate() 
    {
        character.WallMove();

        if (!character.OnEye)
        {
            stateMachine.ChangeState(character.airState);
        }
        if (character.OnGround)
        {
            stateMachine.ChangeState(character.standState);
        }
    }
}