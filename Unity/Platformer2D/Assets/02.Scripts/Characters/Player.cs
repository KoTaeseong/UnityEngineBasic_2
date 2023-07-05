using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


using UnityEngine.InputSystem;

public class Player : Character
{
    private PlayerInput playerInput;
    private float _horizontal;
    private float _vertical;

    protected override void Awake()
    {
        base.Awake();
        playerInput = GetComponent<PlayerInput>();
        //InputAction crouchAction = playerInput.currentActionMap.FindAction("Crouch");
        //crouchAction.performed += ctx => stateMachine.ChangeState(StateType.Crouch);
        //crouchAction.canceled += ctx => stateMachine.ChangeState(StateType.StandUp);

        InputAction jumpAction = playerInput.currentActionMap.FindAction("Jump");
        jumpAction.performed += ctx 
            => stateMachine.ChangeState(stateMachine.currentType == StateType.Crouch ? StateType.DownJump : StateType.Jump);

        InputAction upAction = playerInput.currentActionMap.FindAction("Up");
        upAction.performed += ctx => stateMachine.ChangeState(StateType.LadderUp);

        InputAction downAction = playerInput.currentActionMap.FindAction("Down");
        downAction.performed += ctx =>
        {
            if (stateMachine.ChangeState(StateType.LadderDown)) { }
            else if (stateMachine.ChangeState(StateType.Crouch)) { }
        }; 
        downAction.canceled += ctx => stateMachine.ChangeState(StateType.StandUp);

    }

    public void OnHorizontal(InputValue value)
    {
        _horizontal = value.Get<float>();
        
        //Debug.Log($"Horizontal: {value.Get<float>()}");
    }

    public void OnVertical(InputValue value)
    {
        _vertical= value.Get<float>();
        //Debug.Log($"Vertical: {value.Get<float>()}");
    }

    public void OnAttack()
    {
        stateMachine.ChangeState(StateType.Attack);
    }

    //public void OnJump()
    //{
    //    stateMachine.ChangeState(StateType.Jump);
    //}

    private void Update()
    {
        movement.horizontal = _horizontal;
        if (_horizontal > 0)
        {
            movement.direction = Movement.DIRECTION_RIGHT;
        }
        else if (_horizontal < 0)
        {
            movement.direction = Movement.DIRECTION_LEFT;
        }
    }
}
