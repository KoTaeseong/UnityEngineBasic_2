using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.FSM
{
    public class FallBehaviour : BehaviourBase
    {
        [SerializeField] private float _landingdistance;
        private float _startPosY;

        public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
        {
            base.OnStateMachineEnter(animator, stateMachinePathHash);
            _startPosY = transform.position.y;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);
            if(manager.isGrounded)
            {
                if (_startPosY - transform.position.y < _landingdistance)
                    manager.ChagneState(StateType.Move);
                else
                    manager.ChagneState(StateType.Land);
            }
        }
    }
}

