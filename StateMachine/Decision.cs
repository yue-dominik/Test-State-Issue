namespace Nephtyke.StateMachine;

using Godot;

public abstract partial class Decision: Resource
{
	public abstract bool Decide(StateMachine stateMachine);
}
