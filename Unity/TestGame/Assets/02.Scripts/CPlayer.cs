using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour
{
    Rigidbody2D _rb = null;
    Animator _animator = null;

    [SerializeField] float _moveSpeed = 10.0f;

    [SerializeField] Vector2 _input;

    Vector2 _velocity;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _input.x = Input.GetAxis("Horizontal");
        _input.y = Input.GetAxis("Vertical");

        _velocity.x = (Vector2.right * _input.x * _moveSpeed).x;
        _velocity.y = _rb.velocity.y;

        if (_input.x > 0)
        {
            this.transform.eulerAngles = Vector3.zero;

        }
        else if (_input.x < 0)
        {
            this.transform.eulerAngles = new Vector3(0f,180f,0f);
        }

        if (_rb.velocity.x != 0)
        {
            _animator.SetBool("isMove", true);
        }
        else
        {
            _animator.SetBool("isMove", false);
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = _velocity;
    }
}
