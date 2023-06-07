using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackGround : MonoBehaviour
{
    Rigidbody2D my_rigid;

    void Start()
    {
        my_rigid= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {




        
    }
    private void FixedUpdate()
    {
        
        my_rigid.MovePosition(transform.position + Vector3.down * Time.fixedDeltaTime);


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "BGBoundary")
        {
            transform.position = transform.position + new Vector3(0, 61.373f, 0);

        }


    }

}
