using Godot;
public abstract partial class Action: Resource
{
	
	public bool IsActionFinished;
	public abstract void Act(StateMachine stateMachine);
}
