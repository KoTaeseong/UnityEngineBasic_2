using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMove : MonoBehaviour
{
    public Card card1 = null;
    public Hand hand = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move() 
    {
        Vector3 tVelocity = (hand.transform.position - card1.transform.position).normalized;
        float t = 0.1f;

        while (card1.transform.position != hand.transform.position)
        {
            card1.transform.Translate(tVelocity*t);
        }
    }
}
