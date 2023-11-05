using Godot;


[GlobalClass]
public abstract partial class Decision: Resource
{
	
	public abstract bool Decide(StateMachine stateMachine);
}
