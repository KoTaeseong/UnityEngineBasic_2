using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public bool isMoveable;
    public bool isDirectionChangeable;

    public const int DIRECTION_RIGHT = 1;
    public const int DIRECTION_LEFT = -1;

    public int direction
    {
        get => _direction;
        set
        {
            if(value<0)
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
                _direction = DIRECTION_LEFT;
            }
            else
            {
                transform.eulerAngles = Vector3.zero;
                _direction = DIRECTION_LEFT;
            }
        }
    }

    private int _direction;

    public float horizontal
    {
        get => _horizontal;
        set
        {
            if (_horizontal == value)
                return;

            _horizontal= value;
            //onHorizontalChanged(value); // ����ȣ��  - ��ϵ� �Լ��� ȣ���Ҷ����� ���ڷ� ��������
            //onHorizontalChanged?.Invoke(value);    // ? null üũ ������ - null�̸� (��ϵ� �Լ��� ������) ȣ�� X
            onHorizontalChanged.Invoke(value);//����ȣ��  - Invoke�� �Ű������� �������� �� .. ��ϵ� �Լ����� Invoke�� �Ű������� ����
            //��ϵ� �Լ����� ȣ���Ҷ� �߰��� value�� ���� �ٲ�� ����ȣ���ϰ�� �ٲ� ���� ����������
            //����ȣ���ϰ�� �޸𸮿� �ӽ÷� ���� �����ص� �ٲﰪ�� ȣ����� �ʴ´�.
        }
    }

    private float _horizontal;
    public event Action<float> onHorizontalChanged;
    private Rigidbody2D _rigidbody;
    private Vector2 _move;
    private float _speed = 5;

    private void Awake()
    {
        _rigidbody= GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        if (isMoveable)
            _move = new Vector2(horizontal, 0f);
        else
            _move = Vector2.zero;

        if (isDirectionChangeable)
        {
            if (_horizontal > 0)
                direction = DIRECTION_RIGHT;
            else if (_horizontal < 0)
                direction = DIRECTION_LEFT;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.position += _move * _speed * Time.deltaTime;
    }
}
