using Godot;
using Nephtyke.EventSystem;

namespace Nephtyke.StateMachine;

[GlobalClass]
public partial class FireEventAction: Action
{
	[Export] GameEventChannel[] eventChannels;
	public override void Act(StateMachine stateMachine)
	{
		IsActionFinished = false;
		foreach (GameEventChannel eventChannel in eventChannels)
		{
			eventChannel.Raise();
		}
		IsActionFinished = true;
	}
}
