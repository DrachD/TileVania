public class JumpRunState : AirState
{
    public JumpRunState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }
    public override void Enter() 
    {
        base.Enter();
        onJump = true;
        character.SetBoolAnimator(character.JumpParam, onJump);
        character.SetBoolAnimator(character.SoarParam, onJump);
    }
    public override void Exit() 
    {
        base.Exit();
        onJump = false;
        character.SetBoolAnimator(character.SoarParam, onJump);
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
