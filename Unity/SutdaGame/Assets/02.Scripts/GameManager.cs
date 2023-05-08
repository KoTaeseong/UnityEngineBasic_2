using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : MonoBehaviour
{
    [SerializeField] CDeck mDeck = null;    //�� ���ӿ�����Ʈ
    //[SerializeField] CPlayer mPlayer = null;
    [SerializeField] CPlayer[] mPlayers = null; //�÷��̾� ���� ������Ʈ �迭
    [SerializeField] TMPro.TMP_Text[] mTxtJokbos= null; //���� �ؽ�Ʈ �迭


    List<string> mDrawCardList= new List<string>(); //���� ī�帮��Ʈ��

    Dictionary<string, int> mJokbo = new Dictionary<string, int>()   //����
    {
        // 18����      13����      38����
        {"ch" ,500},{"ac" ,500},{"ah" ,1000},
    
        // 1~10��
        {"aA" ,201},{"bB" ,202},{"cC" ,203},{"dD" ,204},{"eE" ,205},{"fF" ,206},{"gG" ,207},{"hH" ,208},{"iI" ,209},{"jJ" ,220},
    
        //������ 47
        {"dg", 90},
    
         // ���� 94
        //���ֱ���              ����
        {"di" ,50}, {"Di" ,30},{"dI" ,30},{"DI" ,30},
    
        //������ 37
        {"cg" ,20}, {"Cg" ,20},{"cG" ,20},{"CG" ,20},
    
        //4�� �˸� 12
        {"ab" ,106}, {"Ab" ,106},{"aB" ,106},{"AB" ,106},
        //5�� ���� 14
        {"ad" ,105}, {"aD" ,105},{"Ad" ,105},{"AD" ,105},
        //6�� ���� 19
        {"ai" ,104}, {"aI" ,104},{"Ai" ,104},{"AI" ,104},
        //7�� ��� 1 10
        {"aj" ,103}, {"aJ" ,103},{"Aj" ,103},{"AJ" ,103},
        //8�� ��� 4 10
        {"dj" ,102}, {"dJ" ,102},{"Dj" ,102},{"DJ" ,102},
        //9�� ���� 4 6
        {"df" ,101}, {"dF" ,101},{"Df" ,101},{"DF" ,101},
    
        //�����
        {"a" ,1}, {"b" ,2},{"c" ,3},{"d" ,4},{"e" ,5}, {"f" ,6},{"g" ,7},{"h" ,8},{"i" ,9},{"j" ,10},
        {"A" ,1}, {"B" ,2},{"C" ,3},{"D" ,4},{"E" ,5}, {"F" ,6},{"G" ,7},{"H" ,8},{"I" ,9},{"J" ,10}
    };  //����1
    Dictionary<string, string> mJokbo2 = new Dictionary<string, string>()   //����
    {
        // 18����      13����      38����
        {"ch" ,"1,8����"},{"ac" ,"1,3����"},{"ah" ,"3,8����"},
    
        // 1~10��
        {"aA" ,"1,1��"},{"bB" ,"2,2��"},{"cC" ,"2,3��"},{"dD" ,"4,4��"  },{"eE" ,"5,5��"},{"fF" ,"6,6��"},{"gG" ,"7,7��"},{"hH" ,"8,8��"},{"iI" ,"9,9��"},{"jJ" ,"10,10�嶯"},
    
        //������ 47
        {"dg", "7,4������"},
    
         // ���� 94
        //���ֱ���              ����
        {"id" ,"4,9���ֱ���"}, {"iD" ,"4,9����"},{"Id" ,"4,9����"},{"ID" ,"4,9����"},
    
        //������ 37
        {"cg" ,"3,7������"}, {"Cg" ,"3,7������"},{"cG" ,"3,7������"},{"CG" ,"3,7������"},
    
        //4�� �˸� 12
        {"ab" ,"1,2�˸�"}, {"Ab" ,"1,2�˸�"},{"aB" ,"1,2�˸�"},{"AB" ,"1,2�˸�"},
        //5�� ���� 14
        {"ad" ,"1,4����"}, {"aD" ,"1,4����"},{"Ad" ,"1,4����"},{"AD" ,"1,4����"},
        //6�� ���� 19
        {"ai" ,"1,9����"}, {"aI" ,"1,9����"},{"Ai" ,"1,9����"},{"AI" ,"1,9����"},
        //7�� ��� 1 10
        {"aj" ,"1,10���"}, {"aJ" ,"1,10���"},{"Aj" ,"1,10���"},{"AJ" ,"1,10���"},
        //8�� ��� 4 10
        {"dj" ,"4,10���"}, {"dJ" ,"4,10���"},{"Dj" ,"4,10���"},{"DJ" ,"4,10���"},
        //9�� ���� 4 6
        {"df" ,"46����"}, {"dF" ,"46����"},{"Df" ,"46����"},{"DF" ,"46����"},
    };  //����2




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
        mDeck.CreateDeck();
        foreach (var item in mPlayers)
        {
            item.DoClear();
        }
    }

    public void DoDrawCard()
    {
        for (int i = 0; i < mPlayers.Length; i++)
        {
            for (int j = 0; j < 2;)
            {
                int random = UnityEngine.Random.Range(0, mDeck.mDeckCards.Count);   //������ ����
                if (!mDrawCardList.Contains(mDeck.mDeckCards[random]))  //����ī�忡 ���ٸ�
                {
                    mDrawCardList.Add(mDeck.mDeckCards[random]);    //����ī�忡 �߰�

                    GameObject tCard = mDeck.transform.GetChild(0).gameObject; //���� ù��° �ڽ� ī�带 ������
                    tCard.gameObject.name = mDeck.mDeckCards[random];   //�ڽ�ī���� �̸��� �ٲ�
                    tCard.GetComponent<CCard>().TargetPos = mPlayers[i].transform.position + new Vector3(1.2f*j,0.0f,0.0f); //ī���� Ÿ���� �÷��̾�� ����
                    tCard.GetComponent<CCard>().IsMove = true;  //ī���� ������ Ȱ��ȭ
                    tCard.transform.SetParent(mPlayers[i].transform);   //ī���� �θ� �÷��̾�� ����

                    j++;
                }
            }
        }
    }

    public void DoCheckJokbo()
    {
        for (int i = 0; i < mPlayers.Length; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                string tCard = mPlayers[i].transform.GetChild(j).gameObject.name;
                mPlayers[i].myCard.Add(tCard);
            }

            mPlayers[i].myCard.Sort();
            string tPayerCard = mPlayers[i].myCard[0] + mPlayers[i].myCard[1];

            Debug.Log($"�÷��̾�{i}�� ī�� {tPayerCard.ToString()}.");

            //���� ������ �ִٸ�
            if (mJokbo.ContainsKey(tPayerCard))
            {
                
            }

        }
    }

}
