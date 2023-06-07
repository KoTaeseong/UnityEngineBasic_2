using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    Rigidbody2D my_rigid;

    public Vector2 inputVec;
    

    public float my_speed = 10;

    float fire_delay= .2f;
    float cur_delay = 0;
    float bullet_speed = 10;

    bool hit_leftbox =false;
    bool hit_rightbox = false;
    bool hit_topbox = false;
    bool hit_bottombox = false;

    public float score = 0;
    
    public float max_hp=10;
    public float cur_hp; 

    public ObjectManager obj_manager;
    

    void Start()
    {
        my_rigid= GetComponent<Rigidbody2D>();
        cur_hp = max_hp;
    }

    // Update is called once per frame
    void Update()
    {
        cur_delay = cur_delay + Time.deltaTime; //0.001

        inputVec.x = Input.GetAxisRaw("Horizontal");
        
        if ((hit_leftbox&&inputVec.x==-1) || (hit_rightbox && inputVec.x == 1))
        {
            inputVec.x = 0;
        }

        inputVec.y = Input.GetAxisRaw("Vertical");

        if ((hit_topbox && inputVec.y == 1) || (hit_bottombox && inputVec.y == -1))
        {
            inputVec.y = 0;
        }

        Fire();
             
    }

    private void FixedUpdate()
    {
        inputVec = inputVec.normalized * my_speed *Time.deltaTime;

        my_rigid.MovePosition(my_rigid.position + inputVec);

    }

    void Fire()
    {
        if (cur_delay < fire_delay)
            return;

        GameObject bullet_info = obj_manager.SelectObj("PlayerBullet");
        bullet_info.transform.position = gameObject.transform.position;

        Rigidbody2D bullet_rigid = bullet_info.GetComponent<Rigidbody2D>();

        bullet_rigid.AddForce(Vector2.up * bullet_speed, ForceMode2D.Impulse);

        cur_delay = 0;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "Boundary")
        {
            if (collision.transform.name == "LeftBoundary")
            {
                hit_leftbox = true;
            }
            else if (collision.transform.name == "RightBoundary")
            {
                hit_rightbox = true;
            }
            else if (collision.transform.name == "TopBoundary")
            {
                hit_topbox = true;
            }
            else if (collision.transform.name == "BottomBoundary")
            {
                hit_bottombox = true;
            }




        }

        if (collision.gameObject.tag == "Enemy")
        {
            Hit(1);
            collision.gameObject.SetActive(false);
            
        }

        if (collision.gameObject.tag == "EnemyBullet")
        {
            Hit(1);
            collision.gameObject.SetActive(false);
        }


        //if (collision.transform.tag == "Boundary")
        //{
        //    switch (collision.transform.name)
        //    {
        //        case "LeftBoundary":
        //            hit_leftbox = true;
        //            break;

        //        case "RightBoundary":
        //            hit_rightbox = true;
        //            break;

        //        case "TopBoundary":
        //            hit_topbox = true;
        //            break;

        //        case "BottomBoundary":
        //            hit_bottombox = true;
        //            break;

        //    }


        //}




    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Boundary")
        {
            switch (collision.transform.name)
            {
                case "LeftBoundary":
                    hit_leftbox = false;
                    break;

                case "RightBoundary":
                    hit_rightbox = false;
                    break;

                case "TopBoundary":
                    hit_topbox = false;
                    break;

                case "BottomBoundary":
                    hit_bottombox = false;
                    break;

            }
        }
    }

    void Hit(float dmg)
    {
        cur_hp = cur_hp - dmg;

        if (cur_hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
