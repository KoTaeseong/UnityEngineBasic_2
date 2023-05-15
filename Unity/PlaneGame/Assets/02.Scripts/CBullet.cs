using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb = null;

    [SerializeField] float mSpeed = 10.0f;

    Vector3 mVelocity;

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        mVelocity = Vector3.up * mSpeed;

        rb.AddForce(mVelocity,ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    void DisableObject()
    {
        this.gameObject.SetActive(false);
    }
}
