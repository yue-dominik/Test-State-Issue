namespace Nephtyke.StateMachine;

using Godot;

[GlobalClass]
public partial class Transition: Resource
{
	[Export] public Decision Decision;
	[Export] public State TransitionState;
}
