using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CBackGround : MonoBehaviour
{
    [SerializeField] GameObject[] mGameObejct = null;

    [SerializeField] float mBGSpeed = 3.0f;

    [SerializeField]
    float mEdge = 0.0f;

    Vector3 mVelocity;
    Vector3 mOriginPos;

    // Start is called before the first frame update
    void Start()
    {
        mOriginPos = mGameObejct[mGameObejct.Length -1].transform.position;

        mVelocity = Vector3.down * mBGSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < mGameObejct.Length; i++)
        {
            GameObject t = mGameObejct[i];
            t.transform.Translate(mVelocity*Time.deltaTime);

            if (t.transform.position.y < mEdge)
            {
                float tRange = t.transform.position.y - mEdge;

                t.transform.position = mOriginPos - new Vector3(0.0f,tRange, 0.0f);
            }
        }
    }
}
