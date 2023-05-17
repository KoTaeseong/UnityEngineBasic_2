using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBullet2 : MonoBehaviour
{
    Rigidbody2D rb = null;

    [SerializeField] float mSpeed = 10.0f;
    [SerializeField] int damage = 5;

    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }

    public Vector3 mVelocity;

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        mVelocity = Vector3.down * mSpeed;
    }

    private void OnEnable()
    {
        

        rb.AddForce(mVelocity, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y >= 8.0f)
        {
            this.gameObject.SetActive(false);
        }
        if (this.transform.position.y <= -8.0f)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        
    }

    void DisableObject()
    {
        this.gameObject.SetActive(false);
    }
}
