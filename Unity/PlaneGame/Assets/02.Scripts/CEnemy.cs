using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb = null;

    [SerializeField] float mSpeed = 10.0f;

    Vector3 mVelocity;

    [SerializeField] public Vector3 mStartPos;
    [SerializeField] public Vector3 mEndPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        mVelocity = (mEndPos - mStartPos).normalized * mSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = mVelocity;
    }
}
