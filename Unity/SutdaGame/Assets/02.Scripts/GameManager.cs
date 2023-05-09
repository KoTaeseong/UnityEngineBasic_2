using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : MonoBehaviour
{
    [SerializeField] CDeck mpDeck = null;    //덱 게임오브젝트
    //[SerializeField] CPlayer mPlayer = null;
    [SerializeField] CPlayer[] mpPlayers = null; //플레이어 게임 오브젝트 배열
    [SerializeField] TMPro.TMP_Text[] mpTxtJokbos= null; //족보 텍스트 배열
    [SerializeField] TMPro.TMP_Text mpTxtResult= null; //족보 텍스트 배열

    [SerializeField] Sprite[] mpSprite = null;   //스프라이트 소스


    List<string> mDrawCardList= new List<string>(); //뽑은 카드리스트들

    Dictionary<string, int> mJokbo = new Dictionary<string, int>()   //족보
    {
        // 18광땡      13광땡      38광땡
        {"ch" ,500},{"ac" ,500},{"ah" ,1000},
    
        // 1~10땡
        {"aA" ,201},{"bB" ,202},{"cC" ,203},{"dD" ,204},{"eE" ,205},{"fF" ,206},{"gG" ,207},{"hH" ,208},{"iI" ,209},{"jJ" ,220},
    
        //암행어사 47
        {"dg", 90},
    
         // 재경기 94
        //멍텅구리              구사
        {"di" ,50}, {"Di" ,30},{"dI" ,30},{"DI" ,30},
    
        //땡잡이 37
        {"cg" ,20}, {"Cg" ,20},{"cG" ,20},{"CG" ,20},
    
        //4등 알리 12
        {"ab" ,106}, {"Ab" ,106},{"aB" ,106},{"AB" ,106},
        //5등 독사 14
        {"ad" ,105}, {"aD" ,105},{"Ad" ,105},{"AD" ,105},
        //6등 구삥 19
        {"ai" ,104}, {"aI" ,104},{"Ai" ,104},{"AI" ,104},
        //7등 장삥 1 10
        {"aj" ,103}, {"aJ" ,103},{"Aj" ,103},{"AJ" ,103},
        //8등 장사 4 10
        {"dj" ,102}, {"dJ" ,102},{"Dj" ,102},{"DJ" ,102},
        //9등 세륙 4 6
        {"df" ,101}, {"dF" ,101},{"Df" ,101},{"DF" ,101},
    
        //끝계산
        {"a" ,1}, {"b" ,2},{"c" ,3},{"d" ,4},{"e" ,5}, {"f" ,6},{"g" ,7},{"h" ,8},{"i" ,9},{"j" ,10},
        {"A" ,1}, {"B" ,2},{"C" ,3},{"D" ,4},{"E" ,5}, {"F" ,6},{"G" ,7},{"H" ,8},{"I" ,9},{"J" ,10}
    };  //족보1
    Dictionary<string, string> mJokbo2 = new Dictionary<string, string>()   //족보
    {
        // 18광땡      13광땡      38광땡
        {"ch" ,"1,8광땡"},{"ac" ,"1,3광땡"},{"ah" ,"3,8광땡"},
    
        // 1~10땡
        {"aA" ,"1,1떙"},{"bB" ,"2,2땡"},{"cC" ,"2,3땡"},{"dD" ,"4,4떙"  },{"eE" ,"5,5땡"},{"fF" ,"6,6땡"},{"gG" ,"7,7땡"},{"hH" ,"8,8땡"},{"iI" ,"9,9땡"},{"jJ" ,"10,10장땡"},
    
        //암행어사 47
        {"dg", "7,4암행어사"},
    
         // 재경기 94
        //멍텅구리              구사
        {"id" ,"4,9멍텅구리"}, {"iD" ,"4,9파토"},{"Id" ,"4,9파토"},{"ID" ,"4,9파토"},
    
        //땡잡이 37
        {"cg" ,"3,7땡잡이"}, {"Cg" ,"3,7땡잡이"},{"cG" ,"3,7땡잡이"},{"CG" ,"3,7땡잡이"},
    
        //4등 알리 12
        {"ab" ,"1,2알리"}, {"Ab" ,"1,2알리"},{"aB" ,"1,2알리"},{"AB" ,"1,2알리"},
        //5등 독사 14
        {"ad" ,"1,4독사"}, {"aD" ,"1,4독사"},{"Ad" ,"1,4독사"},{"AD" ,"1,4독사"},
        //6등 구삥 19
        {"ai" ,"1,9구삥"}, {"aI" ,"1,9구삥"},{"Ai" ,"1,9구삥"},{"AI" ,"1,9구삥"},
        //7등 장삥 1 10
        {"aj" ,"1,10장삥"}, {"aJ" ,"1,10장삥"},{"Aj" ,"1,10장삥"},{"AJ" ,"1,10장삥"},
        //8등 장사 4 10
        {"dj" ,"4,10장사"}, {"dJ" ,"4,10장사"},{"Dj" ,"4,10장사"},{"DJ" ,"4,10장사"},
        //9등 세륙 4 6
        {"df" ,"46세륙"}, {"dF" ,"46세륙"},{"Df" ,"46세륙"},{"DF" ,"46세륙"},
    };  //족보2

    List<int> mPlayerValues = new List<int>();




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoTableSetting()
    {
        mpDeck.CreateDeck();
        foreach (var item in mpPlayers)
        {
            item.DoClear();
        }

        mDrawCardList.Clear();
        mPlayerValues.Clear();

        for (int i = 0; i < mpPlayers.Length; i++)
        {
            mpTxtJokbos[i].text = "";
        }

        mpTxtResult.text = "";

        //오브젝트 정리
        for (int i = 0; i < mpPlayers.Length; i++)
        {
            for (int j = 0; j < mpPlayers[i].transform.childCount; j++)
            {
                Destroy(mpPlayers[i].transform.GetChild(j).gameObject);
            }
        }
        for (int j = 0; j < mpDeck.transform.childCount; j++)
        {
            Destroy(mpDeck.transform.GetChild(j).gameObject);
        }

        //오브젝트 생성
        for (int i = 0; i < 12; i++)
        {
            CCard tCard = Instantiate<CCard>(mpDeck.PFCard);
            tCard.transform.SetParent(mpDeck.transform);
        }
    }

    public void DoDrawCard()
    {
        for (int i = 0; i < mpPlayers.Length; i++)
        {
            for (int j = 0; j < 2;)
            {
                int random = UnityEngine.Random.Range(0, mpDeck.mDeckCards.Count);   //랜덤한 숫자
                if (!mDrawCardList.Contains(mpDeck.mDeckCards[random]))  //뽑은카드에 없다면
                {
                    mDrawCardList.Add(mpDeck.mDeckCards[random]);    //뽑은카드에 추가

                    GameObject tCard = mpDeck.transform.GetChild(0).gameObject; //덱의 첫번째 자식 카드를 가져옴
                    tCard.gameObject.name = mpDeck.mDeckCards[random];   //자식카드의 이름을 바꿈
                    tCard.GetComponent<SpriteRenderer>().sprite = mpSprite[random];
                    tCard.GetComponent<CCard>().TargetPos = mpPlayers[i].transform.position + new Vector3(1.2f*j,0.0f,0.0f); //카드의 타깃을 플레이어로 변경
                    tCard.GetComponent<CCard>().IsMove = true;  //카드의 움직임 활성화
                    tCard.transform.SetParent(mpPlayers[i].transform);   //카드의 부모를 플레이어로 변경

                    j++;
                }
            }
        }
    }

    public void DoCheckJokbo()
    {
        for (int i = 0; i < mpPlayers.Length; i++)
        {
            List<string> t = new List<string>();

            for (int j = 0; j < 2; j++)
            {
                t.Add(mpPlayers[i].transform.GetChild(j).name);
            }
            //정렬
            t.Sort();

            Debug.Log(i+"플레이어" +t[0] + t[1]);
            string thand = t[0] + t[1];
            Debug.Log(i + "플레이어" + thand);

            if (mJokbo.ContainsKey(thand))
            {
                mpTxtJokbos[i].text = mJokbo2[thand];
                mPlayerValues.Add(mJokbo[thand]);
            }
            else //끝 계산
            {
                int tInt = mJokbo[t[0]] + mJokbo[t[1]];

                if (tInt >= 10)
                {
                    tInt = Math.Abs(tInt - 10);
                }

                mpTxtJokbos[i].text = tInt.ToString() + "끗";
                mPlayerValues.Add(tInt);
            }
        }
    }

    public void Batting()
    {
        List<int> tList = mPlayerValues;

        int tIndex = 0;

        //멍텅구리 체크
        if (CheckNum(tList, 50, out tIndex))
        {
            //38광땡 18,13광땡 10땡 체크
            if (CheckNum3(tList, 210, 1000))
            {
                //있다면
                tList[tIndex] = 3;
            }
            else
            {
                //없다면
                //Console.WriteLine("재경기");
                mpTxtResult.text = "재경기";
                return;
            }
        }
        //파토 체크
        if (CheckNum(tList, 30, out tIndex))
        {
            //1땡 이상 있는지 체크
            if (CheckNum3(tList, 201, 1000))
            {
                //있다면
                tList[tIndex] = 3;
            }
            else
            {
                //없다면
                //Console.WriteLine("재경기");
                mpTxtResult.text = "재경기";
                return;
            }
        }
        //암행어사
        if (CheckNum(tList, 90, out tIndex))
        {
            //광땡 체크
            if (CheckNum2(tList, 500))
            {
                //있다면
                tList[tIndex] = 501;
            }
            else
            {
                //없다면
                tList[tIndex] = 1;
            }
        }
        //땡잡이
        if (CheckNum(tList, 20, out tIndex))
        {
            //1~9떙 체크
            if (CheckNum3(tList, 201, 209))
            {
                //있다면
                tList[tIndex] = 210;
            }
            else
            {
                //없다면
                tList[tIndex] = 0;
            }
        }


        //최종 비교
        for (int i = 0; i < tList.Count; i++)
        {
            //Console.Write($"{tList[i]} ");
        }
        //Console.WriteLine();


        //값들을 리스트에 넣음
        List<int> list = new List<int>();
        for (int i = 0; i < tList.Count; i++)
        {
            list.Add(tList[i]);
        }
        //정렬
        list.Sort();
        //최고값
        int tt = list[list.Count - 1];
        //최고값을 가진 플레이어 찾기
        int tPlayer = 0;
        for (int i = 0; i < tList.Count; i++)
        {
            if (tList[i] == tt)
            {
                tPlayer = i;
                break;
            }
        }

        if (tPlayer == 0)
        {
            //Console.WriteLine("당신이 이겼습니다");
            mpTxtResult.text = "당신이 이겼습니다";
        }
        else
        {
            //Console.WriteLine($"{tPlayer}컴퓨터가 이겼습니다.");
            mpTxtResult.text = tPlayer.ToString() + "컴퓨터가 이겼습니다" ;
        }
    }

    bool CheckNum(List<int> tList, int tValue, out int tIndex)
    {
        for (int i = 0; i < tList.Count; i++)
        {
            if (tList[i] == tValue)
            {
                tIndex = i;
                return true;
            }
        }
        tIndex = -1;
        return false;
    }

    //특정 족보 있는지 체크
    bool CheckNum2(List<int> tList, int tValue)
    {
        for (int i = 0; i < tList.Count; i++)
        {
            if (tList[i] == tValue)
            {

                return true;
            }
        }
        return false;
    }

    //범위 체크
    bool CheckNum3(List<int> tList, int tMinValue, int tMaxValue)
    {
        for (int i = 0; i < tList.Count; i++)
        {
            if (tList[i] >= tMinValue &&
                tList[i] <= tMaxValue)
            {
                return true;
            }
        }
        return false;
    }

}
