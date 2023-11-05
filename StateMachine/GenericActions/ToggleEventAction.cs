using Godot;
using Nephtyke.EventSystem;

namespace Nephtyke.StateMachine;

[GlobalClass]
public partial class ToggleEventAction: Action
{
	
	[Export] GameEventChannel[] eventChannels;
	[Export] bool toggleTo;
	public override void Act(StateMachine stateMachine)
	{
		IsActionFinished = false;
		foreach (GameEventChannel eventChannel in eventChannels)
		{
			eventChannel.IsEnabled = toggleTo;
		}
		IsActionFinished = true;
	}
}
