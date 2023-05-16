using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSpawner : MonoBehaviour
{
    [SerializeField] GameObject SpawnLange1 = null;
    [SerializeField] GameObject SpawnLange2 = null;

    [SerializeField] GameObject[] PFEnemyList = null;
    [SerializeField] GameObject[] PFObjectList = null;

    [SerializeField] GameObject[] mStartPosList = null;
    [SerializeField] GameObject[] mEndPosList = null;

    [SerializeField] float mCreateCycle = 1.0f;

    [SerializeField] int mReadyEnemyCount = 20;
    [SerializeField] int mReadyObjectCount = 20;

    List<GameObject> mEnemyList = new List<GameObject>();
    List<GameObject> mObjectList = new List<GameObject>();

    float x1 = 0f;
    float x2 = 0f;
    float y = 0f;

    int mEnemyIndex = 0;
    int mObjectIndex = 0;

    private void Awake()
    {
        x1 = SpawnLange1.transform.position.x;
        x2 = SpawnLange2.transform.position.x;
        y = SpawnLange1.transform.position.y;

        for (int i = 0; i < mReadyEnemyCount; i++)
        {
            int j = Random.Range(0, PFEnemyList.Length);
            GameObject t = Instantiate(PFEnemyList[j],this.transform.position, Quaternion.identity);
            t.transform.SetParent(this.transform);
            t.SetActive(false);
            mEnemyList.Add(t);
        }

        for (int i = 0; i < mReadyEnemyCount; i++)
        {
            int j = Random.Range(0, PFObjectList.Length);
            GameObject t = Instantiate(PFObjectList[j],this.transform.position, Quaternion.identity);
            t.transform.SetParent(this.transform);
            t.SetActive(false);
            mObjectList.Add(t);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy",2.0f, mCreateCycle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        //난수 생성
        int t = Random.Range(0, 2); //스폰종류  0: 적  1: 오브젝트
        int PN = Random.Range(0, mStartPosList.Length + 1); //경로

        //경로설정
        Vector2 tS = Vector2.one;
        Vector2 tE = Vector2.one;
        if (PN == 0)
        {
            tS = new Vector2(Random.Range(x1, x2), y);
            tE = new Vector2(tS.x, y - 8.0f);
        }
        else
        {
            tS = mStartPosList[PN - 1].transform.position;
            tE = mEndPosList[PN - 1].transform.position;
        }

        //적또는 오브젝트 설정
        if (t == 0)
        {
            GameObject tEnemy = mEnemyList[mEnemyIndex];
            tEnemy.transform.position = tS;
            tEnemy.GetComponent<CEnemy>().SetHp();
            tEnemy.GetComponent<CEnemy>().UpdateVelocity(tS, tE);
            tEnemy.SetActive(true);
            mEnemyIndex++;
            if (mEnemyIndex == mReadyEnemyCount)
            {
                mEnemyIndex = 0;
            }
        }
        else if (t == 1)
        {
            GameObject tObject = mObjectList[mObjectIndex];
            tObject.transform.position = tS;
            tObject.GetComponent<CObject>().SetHp();
            tObject.GetComponent<CObject>().UpdateVelocity(tS, tE);
            tObject.SetActive(true);
            mObjectIndex++;
            if (mObjectIndex == mReadyObjectCount)
            {
                mObjectIndex = 0;
            }
        }
    }
}
