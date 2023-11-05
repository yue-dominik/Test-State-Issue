using Godot;
using Nephtyke.EventSystem;

namespace Nephtyke.StateMachine;

[GlobalClass]
public partial class EventTransition: Resource
{
	[Export] public GameEventChannel channel;
	[Export] public State transitionState;

	private InCodeListener transitionListener;

	public void EnableTransition(StateMachine stateMachine)
	{
		transitionListener = new InCodeListener(channel);
		transitionListener.Fired += () =>
		{
			stateMachine.ChangeState(transitionState);
		};
		transitionListener.EnableListener();
	}

	public void DisableTransition(StateMachine stateMachine)
	{
		transitionListener.DisableListener();
		transitionListener = null;
	}
}
