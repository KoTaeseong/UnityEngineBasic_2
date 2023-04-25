using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_card : MonoBehaviour
{
    Rigidbody2D my_rigid;
    Vector2 my_position;
    Vector2 hand_position;

    [SerializeField] private GameObject Hand;

    void Start()
    {
        my_rigid = GetComponent<Rigidbody2D>();
        my_position = this.transform.position;
        hand_position = Hand.transform.position;

        Vector2 tVelocity = (hand_position - my_position).normalized;

        Debug.Log("my_position " + my_position.ToString());
        Debug.Log("hand_position " + hand_position.ToString());
        Debug.Log(tVelocity.ToString());
    }

    // Update is called once per frame
    void Update()
    {
    }
}
