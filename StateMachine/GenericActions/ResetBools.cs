using Godot;
using Nephtyke.ResourceVariables;

namespace Nephtyke.StateMachine;

[GlobalClass]
public partial class ResetBools: Action
{
	[Export] BoolResource[] boolsToReset;
	[Export] bool resetValue;
	public override void Act(StateMachine stateMachine)
	{
		foreach (BoolResource boolToReset in boolsToReset)
		{
			boolToReset.Value = resetValue;
		}
	}
}