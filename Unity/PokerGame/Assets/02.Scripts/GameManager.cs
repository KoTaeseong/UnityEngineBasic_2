using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject PFCard = null;  //������ ī�� ������Ʈ
    [SerializeField] Sprite[] CardSprites = null;   //ī�� �׸�

    [SerializeField] GameObject Deck = null;

    List<GameObject> CardObjectList = new List<GameObject>(); //������ ī�带 ���� ����Ʈ

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
        CardObjectList.Clear(); //����Ʈ �ʱ�ȭ

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
