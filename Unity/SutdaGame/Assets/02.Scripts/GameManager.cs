using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : MonoBehaviour
{
    [SerializeField] CDeck mpDeck = null;    //�� ���ӿ�����Ʈ
    //[SerializeField] CPlayer mPlayer = null;
    [SerializeField] CPlayer[] mpPlayers = null; //�÷��̾� ���� ������Ʈ �迭
    [SerializeField] TMPro.TMP_Text[] mpTxtJokbos= null; //���� �ؽ�Ʈ �迭
    [SerializeField] TMPro.TMP_Text mpTxtResult= null; //���� �ؽ�Ʈ �迭

    [SerializeField] Sprite[] mpSprite = null;   //��������Ʈ �ҽ�


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

        //������Ʈ ����
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

        //������Ʈ ����
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
                int random = UnityEngine.Random.Range(0, mpDeck.mDeckCards.Count);   //������ ����
                if (!mDrawCardList.Contains(mpDeck.mDeckCards[random]))  //����ī�忡 ���ٸ�
                {
                    mDrawCardList.Add(mpDeck.mDeckCards[random]);    //����ī�忡 �߰�

                    GameObject tCard = mpDeck.transform.GetChild(0).gameObject; //���� ù��° �ڽ� ī�带 ������
                    tCard.gameObject.name = mpDeck.mDeckCards[random];   //�ڽ�ī���� �̸��� �ٲ�
                    tCard.GetComponent<SpriteRenderer>().sprite = mpSprite[random];
                    tCard.GetComponent<CCard>().TargetPos = mpPlayers[i].transform.position + new Vector3(1.2f*j,0.0f,0.0f); //ī���� Ÿ���� �÷��̾�� ����
                    tCard.GetComponent<CCard>().IsMove = true;  //ī���� ������ Ȱ��ȭ
                    tCard.transform.SetParent(mpPlayers[i].transform);   //ī���� �θ� �÷��̾�� ����

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
            //����
            t.Sort();

            Debug.Log(i+"�÷��̾�" +t[0] + t[1]);
            string thand = t[0] + t[1];
            Debug.Log(i + "�÷��̾�" + thand);

            if (mJokbo.ContainsKey(thand))
            {
                mpTxtJokbos[i].text = mJokbo2[thand];
                mPlayerValues.Add(mJokbo[thand]);
            }
            else //�� ���
            {
                int tInt = mJokbo[t[0]] + mJokbo[t[1]];

                if (tInt >= 10)
                {
                    tInt = Math.Abs(tInt - 10);
                }

                mpTxtJokbos[i].text = tInt.ToString() + "��";
                mPlayerValues.Add(tInt);
            }
        }
    }

    public void Batting()
    {
        List<int> tList = mPlayerValues;

        int tIndex = 0;

        //���ֱ��� üũ
        if (CheckNum(tList, 50, out tIndex))
        {
            //38���� 18,13���� 10�� üũ
            if (CheckNum3(tList, 210, 1000))
            {
                //�ִٸ�
                tList[tIndex] = 3;
            }
            else
            {
                //���ٸ�
                //Console.WriteLine("����");
                mpTxtResult.text = "����";
                return;
            }
        }
        //���� üũ
        if (CheckNum(tList, 30, out tIndex))
        {
            //1�� �̻� �ִ��� üũ
            if (CheckNum3(tList, 201, 1000))
            {
                //�ִٸ�
                tList[tIndex] = 3;
            }
            else
            {
                //���ٸ�
                //Console.WriteLine("����");
                mpTxtResult.text = "����";
                return;
            }
        }
        //������
        if (CheckNum(tList, 90, out tIndex))
        {
            //���� üũ
            if (CheckNum2(tList, 500))
            {
                //�ִٸ�
                tList[tIndex] = 501;
            }
            else
            {
                //���ٸ�
                tList[tIndex] = 1;
            }
        }
        //������
        if (CheckNum(tList, 20, out tIndex))
        {
            //1~9�� üũ
            if (CheckNum3(tList, 201, 209))
            {
                //�ִٸ�
                tList[tIndex] = 210;
            }
            else
            {
                //���ٸ�
                tList[tIndex] = 0;
            }
        }


        //���� ��
        for (int i = 0; i < tList.Count; i++)
        {
            //Console.Write($"{tList[i]} ");
        }
        //Console.WriteLine();


        //������ ����Ʈ�� ����
        List<int> list = new List<int>();
        for (int i = 0; i < tList.Count; i++)
        {
            list.Add(tList[i]);
        }
        //����
        list.Sort();
        //�ְ�
        int tt = list[list.Count - 1];
        //�ְ��� ���� �÷��̾� ã��
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
            //Console.WriteLine("����� �̰���ϴ�");
            mpTxtResult.text = "����� �̰���ϴ�";
        }
        else
        {
            //Console.WriteLine($"{tPlayer}��ǻ�Ͱ� �̰���ϴ�.");
            mpTxtResult.text = tPlayer.ToString() + "��ǻ�Ͱ� �̰���ϴ�" ;
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

    //Ư�� ���� �ִ��� üũ
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

    //���� üũ
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
