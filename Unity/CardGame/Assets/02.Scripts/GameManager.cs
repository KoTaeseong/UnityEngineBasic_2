using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using System;
using System.Data;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] card;
    public Sprite[] my_sprites; 
    SpriteRenderer card_renderer;

    List<string> card_list= new List<string>();
    List<int> card_list_numOnly = new List<int>();
    List<char> card_list_shapeOnly = new List<char>();

    List<int> randNumList = new List<int>();

    [SerializeField] TMPro.TMP_Text txtCheck = null;
    [SerializeField] TMPro.TMP_Text txtChagne = null;

    int changeCount = 0;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (changeCount > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                bool isCollision = false;

                RaycastHit hit;
                isCollision = Physics.Raycast(ray,out hit, Mathf.Infinity);

                if (isCollision)
                {
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = my_sprites[randNumList[5]];

                    changeCount --;
                    txtChagne.text = "Change : " + changeCount;
                }
            }
        }
    }

    public void DoDrawCard()
    {
        //초기화
        randNumList.Clear();

        //스프라이트 6개 선정
        for (int i = 0; i < card.Length + 1;)
        {
            int random = UnityEngine.Random.Range(0, my_sprites.Length);

            if (randNumList.Contains(random))
            {
                continue;
            }
            else
            {
                randNumList.Add(random);
                i++;
            }
        }


        //카드 5장 위치 초기화
        for (int i = 0; i < card.Length; i++)
        {
            card[i].transform.position = new Vector3 (0.0f,3.0f, 0.0f);
            card[i].GetComponent<Move_card>().isMove = true;
        }


        //카드 5장 이미지 변경
        for (int i = 0; i < card.Length; i++)
        {
            card_renderer = card[i].GetComponent<SpriteRenderer>();
            card_renderer.sprite = my_sprites[randNumList[i]];
        }


        //텍스트 초기화
        txtCheck.text = "";

        changeCount = 1;
        txtChagne.text = "Change : " + changeCount;
    }
    public void DoCheck()
    {
        //뽑은 카드의 족보 체크
        CheckMyCard(card, card_list_numOnly, card_list_shapeOnly);
    }
    void CheckMyCard(GameObject[] card, List<int> card_list_numOnly, List<char> card_list_shapeOnly)
    {
        //카드 정보 초기화
        card_list_shapeOnly.Clear();
        card_list_numOnly.Clear();

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


        String tCheck = null;

        //플러시
        if (card_list_shapeOnly[0] == card_list_shapeOnly[4])
        {
            Debug.Log("flush");
            tCheck += "flush";
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
                    Debug.Log("straight");
                    tCheck += "straight";
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
                Debug.Log("onepair");
                tCheck += "onepair";
                break;
            case 2:
                Debug.Log("twopair");
                tCheck += "twopair";
                break;
            case 3:
                Debug.Log("triple");
                tCheck += "triple";
                break;
            case 4:
                Debug.Log("fullhouse");
                tCheck += "fullhouse";
                break;
            case 6:
                Debug.Log("fourcard");
                tCheck += "fourcard";
                break;
        }

        if (tCheck == null)
        {
            tCheck += "Nothing";
        }

        txtCheck.text = tCheck;
    }


}
