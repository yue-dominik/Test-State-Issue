using Godot;

public enum ActionsGroup
{
	Start,
	Update,
	Exit,
}

[GlobalClass]
public partial class CheckAllActionsFinished: Decision
{
	[Export] ActionsGroup actionsGroupToCheck = ActionsGroup.Start;

	public override bool Decide(StateMachine stateMachine)
	{
		Action[] actionsToCheck = GetActionsToCheck(stateMachine);
		foreach (Action action in actionsToCheck)
		{
			if (!action.IsActionFinished) return false;
		}
		return true;
	}
	private Action[] GetActionsToCheck(StateMachine stateMachine)
	{
		if (actionsGroupToCheck == ActionsGroup.Start)
		{
			return stateMachine.CurrentState.EnterActions;
		}
		if (actionsGroupToCheck == ActionsGroup.Exit)
		{
			return stateMachine.CurrentState.ExitActions;
		}
		return stateMachine.CurrentState.UpdateActions;
	}
}
