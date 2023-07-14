using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StateDie : State
{
    public override bool canExecute => true;

    public StateDie(StateMachine machine) : base(machine)
    {
    }

    public override StateType MoveNext()
    {
        StateType next = StateType.Die;

        switch (currentStep)
        {
            case IStateEnumerator<StateType>.Step.None:
                {
                    movement.isMoveable = false;
                    movement.isDirectionChangeable = false;
                    animator.Play("Die");

                    currentStep++;
                }
                break;
            case IStateEnumerator<StateType>.Step.Start:
                {
                    
                    currentStep++;
                }
                break;
            case IStateEnumerator<StateType>.Step.Casting:
                {
                    currentStep++;
                }
                break;
            case IStateEnumerator<StateType>.Step.DoAction:
                {
                    currentStep++;
                }
                break;
            case IStateEnumerator<StateType>.Step.WaitUntilActionFinished:
                {
                    if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                    {
                        currentStep++;
                    }
                }
                break;
            case IStateEnumerator<StateType>.Step.Finish:
                {
                    GameObject.Destroy(machine.gameObject);
                }
                break;
            default:
                break;
        }

        return next;
    }
}
