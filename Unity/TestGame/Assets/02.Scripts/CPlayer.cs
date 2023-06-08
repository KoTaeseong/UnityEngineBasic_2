using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour
{
    Rigidbody2D _rb = null;
    Animator _animator = null;
    BoxCollider2D _childCollider = null;

    [SerializeField] Vector3 PivotOffset = new Vector3(0f,0.534f,0f);
    [SerializeField] float _moveSpeed = 10.0f;
    [SerializeField] Vector2 _input;

    [SerializeField] float _detecRange;

    [SerializeField] GameObject _bullet = null;

    Vector2 _playerCenterPos;
    Vector2 _velocity;

    Vector2 _serchAreaSize;

    public List<GameObject> enemyList = new List<GameObject>();

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _childCollider= GetComponentInChildren<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _childCollider.size = new Vector2(_detecRange,_detecRange);
    }

    // Update is called once per frame
    void Update()
    {
        _playerCenterPos = this.transform.position + PivotOffset;

        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = Input.GetAxisRaw("Vertical");

        //_velocity.x = (Vector2.right * _input.x * _moveSpeed).x;
        //_velocity.y = (Vector2.up * _input.y * _moveSpeed).y;

        _velocity = new Vector2(_input.x, _input.y).normalized;

        if (_input.x > 0)
        {
            this.transform.eulerAngles = Vector3.zero;

        }
        else if (_input.x < 0)
        {
            this.transform.eulerAngles = new Vector3(0f,180f,0f);
        }

        //if (_rb.velocity.x != 0)
        //{
        //    _animator.SetBool("isMove", true);
        //}
        //else
        //{
        //    _animator.SetBool("isMove", false);
        //}

        _animator.SetFloat("Move", Mathf.Abs(_velocity.magnitude));

        if (enemyList.Count != 0)
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                Debug.DrawRay(transform.position, enemyList[i].transform.position - transform.position, Color.red);

                
            }

            //Vector2 dir = enemyList[0].transform.position - transform.position;
            //Debug.Log(Mathf.Sqrt(dir.x * dir.x + dir.y * dir.y).ToString());
            //
            //Debug.Log(Vector2.Distance(transform.position, enemyList[0].transform.position));
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = _velocity * _moveSpeed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireCube(this.transform.position + PivotOffset, new Vector3(_detecRange,_detecRange,0f));
        Gizmos.DrawWireCube(_playerCenterPos, new Vector3(_detecRange,_detecRange,0f));
    }
}
