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
            //onHorizontalChanged(value); // 직접호출  - 등록된 함수를 호출할때마다 인자로 직접참조
            //onHorizontalChanged?.Invoke(value);    // ? null 체크 연산자 - null이면 (등록된 함수가 없으면) 호출 X
            onHorizontalChanged.Invoke(value);//간접호출  - Invoke의 매개변수에 인자전달 후 .. 등록된 함수들은 Invoke의 매개변수를 참조
            //등록된 함수들을 호출할때 중간에 value의 값이 바뀌면 직접호출일경우 바뀐 값이 참조되지만
            //간접호출일경우 메모리에 임시로 값을 저장해둬 바뀐값이 호출되지 않는다.
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
