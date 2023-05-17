using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CActor : MonoBehaviour
{
    public static Vector3 Ppos;

    [SerializeField] float mSpeed = 3.0f;

    Rigidbody2D rb = null;

    float mHorizontal;
    float mVertical;

    Vector2 mVelocity;

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ppos = transform.position;

        mHorizontal = Input.GetAxisRaw("Horizontal");
        mVertical = Input.GetAxisRaw("Vertical");

        mVelocity = (Vector2.right * mHorizontal + Vector2.up* mVertical).normalized * mSpeed;
    }

    private void FixedUpdate()
    {
        rb.velocity = mVelocity;
    }

}
