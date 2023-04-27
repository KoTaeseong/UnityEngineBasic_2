using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using System;

public class GameManager : MonoBehaviour
{
    GameObject[] Deck = new GameObject[52];
    [SerializeField]
    GameObject PFCard = null;


    [SerializeField] GameObject[] card;
    public Sprite[] my_sprites; 
    SpriteRenderer card_renderer;

    List<string> card_list= new List<string>();
    List<int> card_list_numOnly = new List<int>();
    List<char> card_list_shapeOnly = new List<char>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < card.Length; i++)
        {
            card_renderer = card[i].GetComponent<SpriteRenderer>();
            card_renderer.sprite = my_sprites[UnityEngine.Random.Range(0,my_sprites.Length)];
        }
        


        //카드 정보 넣기
        for (int i = 0; i < card.Length; i++)
        {
            card_renderer = card[i].GetComponent<SpriteRenderer>();
            card_list_shapeOnly.Add(Convert.ToChar(card_renderer.sprite.name.Substring(2, 1)));
            card_list_numOnly.Add(Convert.ToInt32(card_renderer.sprite.name.Substring(0, 2)));
        }
        card_list_numOnly.Sort();
        card_list_shapeOnly.Sort();
        CheckMyCard(card ,card_list_numOnly,card_list_shapeOnly);


        //덱 생성
        for (int i = 0; i < my_sprites.Length; i++)
        {
            Deck[i] = Instantiate<GameObject>(PFCard);
            card_renderer = Deck[i].GetComponent<SpriteRenderer>();
            card_renderer.sprite = my_sprites[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckMyCard(GameObject[] card, List<int> card_list_numOnly, List<char> card_list_shapeOnly)
    {
        //플러시
        if (card_list_shapeOnly[0] == card_list_shapeOnly[4])
        {
            Debug.Log("플러시");
            return;
        }

        //스트레이트
        int strateCount = 0;
        for (int i = 0; i < card.Length - 1; i++)
        {
            if (card_list_numOnly[i] + 1 == card_list_numOnly[i + 1])
            {
                strateCount++;
                if (strateCount == 4)
                {
                    Debug.Log("스트레이트");
                    return;
                }
            }
            else
            {
                break;
            }
        }

        //원,투,트리플,풀하우스,포카드
        int count = 0;
        for (int i = 0; i < card.Length - 1; i++)
        {
            for (int j = i + 1; j < card.Length; j++)
            {
                if (card_list_numOnly[i] == card_list_numOnly[j])
                {
                    count++;
                }
            }
        }

        switch (count)
        {
            case 1:
                Debug.Log("원페어");
                break;
            case 2:
                Debug.Log("투페어");
                break;
            case 3:
                Debug.Log("트리플");
                break;
            case 4:
                Debug.Log("풀하우스");
                break;
            case 6:
                Debug.Log("포카드");
                break;
        }
    }

}
