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
        //ī�� 5�� �̹��� ����
        for (int i = 0; i < card.Length; i++)
        {
            card_renderer = card[i].GetComponent<SpriteRenderer>();
            card_renderer.sprite = my_sprites[UnityEngine.Random.Range(0,my_sprites.Length)];
        }
        

        //ī�� ���� �ֱ�
        for (int i = 0; i < card.Length; i++)
        {
            card_renderer = card[i].GetComponent<SpriteRenderer>(); //�������� ���õ� ī���� ��������Ʈ ������ �ֱ�
            card_list.Add(card_renderer.sprite.name);   //ī�帮��Ʈ�� ���� ī�� �ֱ�
            card_list_shapeOnly.Add(Convert.ToChar(card_renderer.sprite.name.Substring(2, 1))); //���� �迭�� ī�� ���� �ֱ�
            card_list_numOnly.Add(Convert.ToInt32(card_renderer.sprite.name.Substring(0, 2)));  //���� �迭�� ī�� ���� �ֱ�

            //Debug.Log(card_list[i]);
        }

        //���� ī���� ������ ����
        card_list_numOnly.Sort();   
        card_list_shapeOnly.Sort();

        //���� ī���� ���� üũ
        CheckMyCard(card ,card_list_numOnly,card_list_shapeOnly);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckMyCard(GameObject[] card, List<int> card_list_numOnly, List<char> card_list_shapeOnly)
    {
        //�÷���
        if (card_list_shapeOnly[0] == card_list_shapeOnly[4])
        {
            Debug.Log("�÷���");
        }

        //��Ʈ����Ʈ
        int strateCount = 0;
        for (int i = 0; i < card.Length - 1; i++)
        {
            if (card_list_numOnly[i] + 1 == card_list_numOnly[i + 1])
            {
                strateCount++;
                if (strateCount == 4)
                {
                    Debug.Log("��Ʈ����Ʈ");
                    return;
                }
            }
            else
            {
                break;
            }
        }

        //��,��,Ʈ����,Ǯ�Ͽ콺,��ī��
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
                Debug.Log("�����");
                break;
            case 2:
                Debug.Log("�����");
                break;
            case 3:
                Debug.Log("Ʈ����");
                break;
            case 4:
                Debug.Log("Ǯ�Ͽ콺");
                break;
            case 6:
                Debug.Log("��ī��");
                break;
        }
    }

}
