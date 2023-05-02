using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject mPFCard = null;  //������ ī�� ������Ʈ
    [SerializeField] Sprite[] mCardSprites = null;   //ī�� �׸�

    [SerializeField] GameObject mDeck = null;
    [SerializeField] GameObject mHand = null;

    List<GameObject> mDeckList = new List<GameObject>(); //������ ī�带 ���� ����Ʈ

    List<GameObject> mMyCardList = new List<GameObject>(); //�÷��̾� �ڵ�

    List<int> mDrawCardList = new List<int>();  //���� ī�� ����Ʈ

    // Start is called before the first frame update
    void Start()
    {
        //CreateDeck();
        
        
             
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateDeck()
    {
        mDeckList.Clear(); //����Ʈ �ʱ�ȭ

        GameObject tCard = null;
        SpriteRenderer tCardRenderer = null;

        for (int i = 0; i < mCardSprites.Length; i++)
        {
            tCard = Instantiate<GameObject>(mPFCard);
            tCardRenderer = tCard.GetComponent<SpriteRenderer>();
            tCardRenderer.sprite = mCardSprites[i];
            tCard.gameObject.name = mCardSprites[i].name;

            tCard.transform.SetParent(mDeck.transform, false);

            mDeckList.Add(tCard);
        }
    }

    public void DrawCard(int tNumb)
    {
        for (int i = 0; i < tNumb;)
        {
            int tRandom = UnityEngine.Random.Range(0, mDeckList.Count);
            if (mDrawCardList.Contains(tRandom))
            {
                continue;
            }
            else
            {
                mMyCardList.Add(mDeckList[tRandom]);
                mDrawCardList.Add(tRandom);
                i++;
            }
        }
    }
}
