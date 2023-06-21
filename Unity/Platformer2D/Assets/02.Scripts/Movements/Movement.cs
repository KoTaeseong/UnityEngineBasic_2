using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
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
            onHorizontalChanged(value);
        }
    }
    private float _horizontal;
    public event Action<float> onHorizontalChanged;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }
}
