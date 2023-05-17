using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CBoss : MonoBehaviour
{
    [SerializeField] GameObject PFBullet = null;
    [SerializeField] int mBulletCount = 20;
    [SerializeField] float mBulletSpeed = 10;

    [SerializeField] Slider hpSlider = null;

    List<GameObject> mBullets = new List<GameObject>();
    int mBulletIndex = 0;

    [SerializeField] private int hp = 100;
    [SerializeField] private int maxhp = 100;

    public int HP
    {
        get { return hp; }
        set { hp = value; }
    }
    public int MaxHP
    {
        get { return maxhp; }
        set { maxhp = value; }
    }

    private void Awake()
    {
        hpSlider.maxValue = maxhp;
        hpSlider.value = hp;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < mBulletCount; i++)
        {
            GameObject t = Instantiate(PFBullet, this.transform.position, Quaternion.identity);
            t.gameObject.SetActive(false);
            t.transform.SetParent(this.transform);
            mBullets.Add(t);
        }

        InvokeRepeating("DoFire", 2.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    void DoFire()
    {
        GameObject t = mBullets[mBulletIndex];
        t.SetActive(false);
        t.GetComponent<CBullet2>().mVelocity = (CActor.Ppos - this.transform.position).normalized * mBulletSpeed;
        t.SetActive(true);
        mBulletIndex++;
        if (mBulletIndex ==mBulletCount)
        {
            mBulletIndex= 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("tagBullet"))
        {
            int t = collision.transform.GetComponent<CBullet>().Damage;
            DoDamage(t);
            collision.gameObject.SetActive(false);
        }
    }

    void DoDamage(int t)
    {
        hp -= t;
        hpSlider.value = hp;
        if (hp <= 0)
        {
            CParticleMgr.action(this.transform.position);
            CUIPlayGame.action(1000);
            this.gameObject.SetActive(false);
        }
    }
}
