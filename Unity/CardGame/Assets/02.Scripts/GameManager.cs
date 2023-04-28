using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] card;
    public Sprite[] my_sprites; 
    SpriteRenderer card_renderer;

    List<string> card_list= new List<string>();
    List<int> card_list_numOnly = new List<int>();
    List<char> card_list_shapeOnly = new List<char>();

    // Start is called before the first frame update
    void Start()
    {
        //카드 5장 이미지 변경
        for (int i = 0; i < card.Length; i++)
        {
            card_renderer = card[i].GetComponent<SpriteRenderer>();
            card_renderer.sprite = my_sprites[UnityEngine.Random.Range(0,my_sprites.Length)];
        }
        

        //카드 정보 넣기
        for (int i = 0; i < card.Length; i++)
        {
            card_renderer = card[i].GetComponent<SpriteRenderer>(); //렌더러에 선택된 카드의 스프라이트 렌더러 넣기
            card_list.Add(card_renderer.sprite.name);   //카드리스트에 뽑은 카드 넣기
            card_list_shapeOnly.Add(Convert.ToChar(card_renderer.sprite.name.Substring(2, 1))); //문자 배열에 카드 문양 넣기
            card_list_numOnly.Add(Convert.ToInt32(card_renderer.sprite.name.Substring(0, 2)));  //숫자 배열에 카드 숫자 넣기

            //Debug.Log(card_list[i]);
        }

        //뽑은 카드의 정보들 정렬
        card_list_numOnly.Sort();   
        card_list_shapeOnly.Sort();

        //뽑은 카드의 족보 체크
        CheckMyCard(card ,card_list_numOnly,card_list_shapeOnly);

        
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
