﻿using System;
using UnityEngine;

public abstract class Character : MonoBehaviour, IHp, IPausable
{
    [Header("Stats")]
    [SerializeField] public float jumpForce;
    [SerializeField] public float downJumpForce = 1.0f;
    [SerializeField] public float landDistance = 1.0f;
    [SerializeField] public float ladderMoveSpeed = 2.0f;

    protected Movement movement;
    protected StateMachine stateMachine;

    public float hp
    {
        get => _hp;
        set
        {
            if (_hp == value)
                return;
            float prev = _hp;
            _hp = value;

            onHpChanged?.Invoke(value);
            if(prev > value)
            {
                onHpDecreased?.Invoke(prev - value);
                if (value <= _hpMin)
                {
                    onHpMin?.Invoke();
                    stateMachine.ChangeState(StateType.Die);
                }
                else
                {
                    stateMachine.ChangeState(StateType.Hurt);
                }
            }
            else if(prev < value)
            {
                onHpIncreased?.Invoke(value - prev);
                if(value >= _hpMax)
                    onHpMax?.Invoke();
            }
        }
    }
    public float hpMin => _hpMin;
    public float hpMax => _hpMax;

    private float _hp;
    private float _hpMin;
    [SerializeField] private float _hpMax;

    public event Action<float> onHpChanged;
    public event Action<float> onHpDecreased;
    public event Action<float> onHpIncreased;
    public event Action onHpMin;
    public event Action onHpMax;

    protected virtual void Awake()
    {
        movement= GetComponent<Movement>();
        stateMachine= GetComponent<StateMachine>();

        movement.onHorizontalChanged += (value) =>
        {
            stateMachine.ChangeState(value == 0.0f ? StateType.Idle : StateType.Move);
        };

        PauseController.instance.Register(this);
        //onHpDecreased += () => stateMachine.ChangeState(StateType.Hurt);
        //onHpMin += stateMachine.ChangeState(StateType.Die);
    }

    protected virtual void Start()
    {
        hp = hpMax;
    }

    public virtual void Damage(GameObject damager, float amount)
    {
        hp -= amount;
    }

    public virtual void Heal(GameObject healer, float amount)
    {
        hp += amount;
    }

    public void Pause(bool pause)
    {
        bool enable = pause == false;
        enabled = enable;
        stateMachine.enabled = enable;
        movement.enabled = enable;
    }
}



