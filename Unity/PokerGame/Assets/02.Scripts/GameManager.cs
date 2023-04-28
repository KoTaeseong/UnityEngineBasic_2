using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject PFCard = null;  //복사할 카드 오브젝트
    [SerializeField] Sprite[] CardSprites = null;   //카드 그림

    [SerializeField] GameObject Deck = null;

    List<GameObject> CardObjectList = new List<GameObject>(); //생성한 카드를 넣을 리스트

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
        CardObjectList.Clear(); //리스트 초기화

        GameObject card = null;
        SpriteRenderer cardRenderer = null;

        for (int i = 0; i < CardSprites.Length; i++)
        {
            card = Instantiate<GameObject>(PFCard);
            cardRenderer = card.GetComponent<SpriteRenderer>();
            cardRenderer.sprite = CardSprites[i];

            card.transform.SetParent(Deck.transform, false);

            CardObjectList.Add(card);
        }
    }
}
