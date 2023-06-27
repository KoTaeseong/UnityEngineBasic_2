using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Player
{


    protected override void Start()
    {
        base.Start();

        //stateMachine.InitStates(new Dictionary<StateType, State>()
        stateMachine.InitStates(new Dictionary<StateType, IStateEnumerator<StateType>>()
        { {StateType.Idle, new StateIdle(stateMachine)},
          {StateType.Move, new StateMove(stateMachine)},
          {StateType.Attack, new StateAttack(stateMachine)},
          {StateType.Hurt, new StateHurt(stateMachine)},
          {StateType.Die, new StateDie(stateMachine)}
        });
    }
}
