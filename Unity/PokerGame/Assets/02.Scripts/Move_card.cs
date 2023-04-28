using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Move_card : MonoBehaviour
{
    [SerializeField] private GameObject Hand;

    Rigidbody2D my_rigid;
    Vector3 my_position;
    Vector3 target_position;
    Vector3 next_position;
    Vector3 tVelocity;

    

    void Start()
    {
        my_rigid = GetComponent<Rigidbody2D>();
        my_position = this.transform.position;
        target_position = Hand.transform.position;
        next_position = target_position - this.target_position;

        
        //tVelocity = (target_position - my_position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position += tVelocity * Time.deltaTime;

        //next_position = target_position - this.transform.position;
        //this.transform.position += next_position.normalized * Time.deltaTime;

        //my_rigid.MovePosition(transform.position + next_position.normalized * Time.deltaTime * 3);

        this.transform.position = Vector3.MoveTowards(transform.position, target_position, 10 * Time.deltaTime);
    }
}
