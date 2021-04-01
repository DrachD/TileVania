using UnityEngine;
public abstract class State
{
    protected float forceX;
    protected bool onGround;
    protected bool onAttack;
    protected StateMachine stateMachine;
    protected Character character;
    protected State(Character character, StateMachine stateMachine)
    {
        this.character = character;
        this.stateMachine = stateMachine;
    }
    protected State() {}
    public virtual void Enter() { }
    public virtual void Exit() {  }
    public virtual void InputHander() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() 
    {
        character.Move(forceX);
    }
}