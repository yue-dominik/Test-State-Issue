using Godot;

[GlobalClass]
public partial class WaitFor: Action
{
	[Export()] float WaitTime;
	public override void Act(StateMachine stateMachine)
	{
		IsActionFinished = false;
		WaitForSeconds(stateMachine);
	}

	async void WaitForSeconds(StateMachine stateMachine)
	{
		await ToSignal(stateMachine.GetTree().CreateTimer(WaitTime), "timeout");
		IsActionFinished = true;
	}
}
