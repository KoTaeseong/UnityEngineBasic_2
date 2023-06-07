using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    Rigidbody2D my_rigid;
    public ObjectManager obj_manger_in_bosscs;
    public GameObject barrel;
    public GameObject player;

    List<GameObject> bullet_arr = new List<GameObject>();
    List<Rigidbody2D> rigid_arr = new List<Rigidbody2D>();


    int patten_select = -1;

    float cur_timer=0;
    float delay_timer=0.7f;

    public float max_hp=100;
    public float cur_hp;

    void Start()
    {
        my_rigid= GetComponent<Rigidbody2D>();
        cur_hp = max_hp;

        Invoke("Patten", 3);
    }

    // Update is called once per frame
    void Update()
    {
        cur_timer = cur_timer + Time.deltaTime;


        transform.position = Vector2.MoveTowards(transform.position,
                                         new Vector2(0, 5), 2 * Time.deltaTime);

        if(cur_timer> delay_timer)
        {
            
            cur_timer = 0;
        }


    }


    void Patten()
    {
        patten_select += 1;

        if (patten_select >= 2)
        {
            patten_select = 0;
        }

        switch (patten_select) 
        {
        
            case 0:
                StartCoroutine(FireCross());
                break;

            case 1:
                StartCoroutine(FireCircle());
                break;
        
        
        }



        
    }


    IEnumerator FireCross()
    {
        for (int i = 0; i < 4; i++)
        {
            bullet_arr.Add(obj_manger_in_bosscs.SelectObj("BossBullet"));
            bullet_arr[i].transform.position = barrel.transform.position;

            rigid_arr.Add(bullet_arr[i].GetComponent<Rigidbody2D>());

            Vector2 bullet_dir = player.transform.position - barrel.transform.position;
            bullet_dir = bullet_dir.normalized;

            rigid_arr[i].AddForce(bullet_dir * 5, ForceMode2D.Impulse);

        }
        yield return new WaitForSeconds(.5f);


        int index=0;
        Vector2 bullet_dir2 = new Vector2(0, 0);
        for(int i = 0; i<4; i++)
        {
            switch (index)
            {
                case 0:
                    bullet_dir2 = new Vector2(1, 0);
                    break;

                case 1:
                    bullet_dir2 = new Vector2(-1, 0);

                    break;

                case 2:
                    bullet_dir2 = new Vector2(0, -1);
                    break;

                case 3:
                    bullet_dir2 = new Vector2(0, 1);
                    break;


            }
            rigid_arr[i].velocity = Vector2.zero;
            rigid_arr[i].AddForce(bullet_dir2 * 3, ForceMode2D.Impulse);


            index++;


        }

        rigid_arr.Clear();
        bullet_arr.Clear();

        Invoke("Patten", 1);

    }


    IEnumerator FireCircle()
    {

        for(int i =0; i<30; i++)
        {

            bullet_arr.Add(obj_manger_in_bosscs.SelectObj("BossBullet"));
            rigid_arr.Add(bullet_arr[i].GetComponent<Rigidbody2D>());
            
            bullet_arr[i].transform.position = barrel.transform.position;

            Vector2 bullet_dir = player.transform.position - barrel.transform.position;
            bullet_dir = bullet_dir.normalized;

            rigid_arr[i].AddForce(bullet_dir * 3, ForceMode2D.Impulse);

        }
        yield return new WaitForSeconds(1);

        for(int i =0; i<30; i++)
        {
            Vector2 bullet_dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / 30),
                                                Mathf.Sin(Mathf.PI * 2 * i / 30));
            
            rigid_arr[i].velocity = Vector2.zero;
            rigid_arr[i].AddForce(bullet_dir.normalized * 3, ForceMode2D.Impulse);

        }

        bullet_arr.Clear();
        rigid_arr.Clear();


        Invoke("Patten", 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            cur_hp = cur_hp - 1;

            collision.gameObject.SetActive(false);

            if (cur_hp < 0)
            {
                gameObject.SetActive(false);
            }

        }
    }
}
