using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

namespace RPG.FSM
{
    public class LandBehaviour : BehaviourBase
    {
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);
            if (stateInfo.normalizedTime >= 1.0f)
                manager.ChagneState(StateType.Move);
        }
    }
}
