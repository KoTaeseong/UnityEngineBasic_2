using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObject : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb = null;

    [SerializeField] int mHP = 10;
    [SerializeField] int mMaxHP = 10;
    [SerializeField] float mSpeed = 3.0f;

    [SerializeField] float mDisablePos = -8.0f;

    public int HP
    {
        get { return mHP; }
        set { mHP = value; }
    }

    public int MaxHP
    {
        get { return mMaxHP; }
        set { mMaxHP = value; }
    }

    Vector2 mVelocity;

    public Vector2 mStartPos;
    public Vector2 mEndPos;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0, 0, 0.5f), Space.World);

        if (this.transform.position.y <= mDisablePos)
        {
            this.gameObject.SetActive(false);
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = mVelocity;
    }

    public void UpdateVelocity(Vector2 tS, Vector2 tE)
    {
        mStartPos = tS;
        mEndPos = tE;
        mVelocity = (mEndPos- mStartPos).normalized * mSpeed;
    }

    public void SetHp()
    {
        mHP = mMaxHP;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("tagBullet"))
        {
            int t = collision.transform.GetComponent<CBullet>().Damage;
            collision.gameObject.SetActive(false);
            DoDamage(t);
        }
    }

    void DoDamage(int t)
    {
        mHP -= t;
        if (mHP <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
