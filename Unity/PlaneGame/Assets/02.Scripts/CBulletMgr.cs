using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBulletMgr : MonoBehaviour
{
    [SerializeField] GameObject PFBullet = null;
    [SerializeField] int mBulletCount = 20;

    List<GameObject> mBullets = new List<GameObject>();

    int mBulletIndex = 0;

    [SerializeField] float mCoolTime = 0.5f;

    bool mDoFire = true;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) &&
            mDoFire)
        {
            DoFire();
        }
    }

    void DoFire()
    {
        GameObject t = mBullets[mBulletIndex];
        t.transform.position = this.transform.position;
        t.gameObject.SetActive(true);

        mBulletIndex++;
        if (mBulletIndex == mBulletCount)
        {
            mBulletIndex = 0;
        }
         mDoFire= false;
        StartCoroutine(CoolTime());
    }

    IEnumerator CoolTime()
    {
        float tTime = 0;
        while (tTime <= mCoolTime)
        {
            tTime += Time.deltaTime;
            yield return null;
        }
        mDoFire = true;
    }
}
