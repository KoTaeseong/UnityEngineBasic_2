using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject mPFCard = null;  //복사할 카드 오브젝트
    [SerializeField] Sprite[] mCardSprites = null;   //카드 그림

    [SerializeField] GameObject mDeck = null;
    [SerializeField] GameObject mHand = null;

    List<GameObject> mDeckList = new List<GameObject>(); //생성한 카드를 넣을 리스트

    List<GameObject> mMyCardList = new List<GameObject>(); //플레이어 핸드

    List<int> mDrawCardList = new List<int>();  //뽑은 카드 리스트

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
        mDeckList.Clear(); //리스트 초기화

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
