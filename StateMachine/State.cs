namespace Nephtyke.StateMachine;

using Godot;

[GlobalClass]
public partial class State: Resource
{
	[Export] public Action[] EnterActions;
    [Export] public Action[] UpdateActions;
    [Export] public Action[] ExitActions;
    [Export] Transition[] transitions;
    [Export] EventTransition[] eventTransitions;


    public virtual void Enter(StateMachine stateMachine)
    {
        if (stateMachine.LogStateData)
        {
            GD.Print("Entered: " + this.ResourceName);
        }

        if (eventTransitions != null)
        {
            foreach (EventTransition eventTransition in eventTransitions)
            {
                eventTransition.EnableTransition(stateMachine);
            }
        }
        DoActions(stateMachine, EnterActions);
    }

    public virtual void UpdateState(StateMachine stateMachine)
    {
        DoActions(stateMachine, UpdateActions);
        CheckTransitions(stateMachine);
    }

    public virtual void Exit(StateMachine stateMachine)
    {
        if (stateMachine.LogStateData)
        {
            GD.Print("Exit: " + this.ResourceName);
        }


        if (eventTransitions != null)
        {
            foreach (EventTransition eventTransition in eventTransitions)
            {
                eventTransition.DisableTransition(stateMachine);
            }
        }
        DoActions(stateMachine, ExitActions);
    }

    private void DoActions(StateMachine stateMachine, Action[] actions)
    {
        foreach (Action action in actions)
        {
            action.Act(stateMachine);
        }
    }

    private void CheckTransitions(StateMachine stateMachine)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            bool decisionSucceeded = transitions[i].Decision.Decide(stateMachine);

            if (decisionSucceeded)
            {
                stateMachine.ChangeState(transitions[i].TransitionState);
                return;
            }
        }
    }

    public virtual void CollectiveCleanup()
    {
    }
}
