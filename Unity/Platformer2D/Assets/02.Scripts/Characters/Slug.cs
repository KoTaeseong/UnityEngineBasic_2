using System.Collections.Generic;

public class Slug : Enemy
{
    protected override void Start()
    {
        base.Start();

        //stateMachine.InitStates(new Dictionary<StateType, State>()
        stateMachine.InitStates(new Dictionary<StateType, IStateEnumerator<StateType>>()
        { {StateType.Idle, new StateIdle(stateMachine)},
          {StateType.Move, new StateMove(stateMachine)}
        });
    }
}
