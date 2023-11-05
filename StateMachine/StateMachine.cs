namespace Nephtyke.StateMachine;

using Godot;

[GlobalClass]
public partial class StateMachine: Node
{
	[Export] public State StartingState;
	[Export] public bool LogStateData;
	public State CurrentState;

	public override void _Ready()
	{
		base._Ready();
		Initialize();
	}

	public void Initialize()
	{
		CurrentState = StartingState;
		CurrentState.Enter(this);
	}

	public void ChangeState(State newState)
	{
		CurrentState.Exit(this);
		CurrentState = newState;
		CurrentState.Enter(this);
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		CurrentState.UpdateState(this);
	}

	private void OnDisable()
	{
		ForceExit();
	}

	public void ForceExit()
	{
		CurrentState.Exit(this);
	}
}
