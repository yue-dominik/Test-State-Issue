using Godot;
using Nephtyke.ResourceVariables;

namespace Nephtyke.StateMachine;

public enum CheckType
{
	And,
	Or,
}

[GlobalClass]
public partial class CheckBools:  Decision
{
	
	[Export] BoolResource[] boolsToCheck;
	[Export] bool checkValue;
	[Export] CheckType checkType = CheckType.And;

	public override bool Decide(StateMachine stateMachine)
	{
		if (checkType == CheckType.And)
		{
			foreach (BoolResource variable in boolsToCheck)
			{
				if (variable.Value != checkValue) return false;
			}
			return true;
		}
		if (checkType == CheckType.Or)
		{
			foreach (BoolResource variable in boolsToCheck)
			{
				if (variable.Value == checkValue) return true;
			}
			return false;
		}

		return false;
	}
}
