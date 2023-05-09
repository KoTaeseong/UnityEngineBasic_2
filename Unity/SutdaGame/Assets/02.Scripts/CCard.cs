using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCard : MonoBehaviour
{
    Vector3 mTargetPos;

    public Vector3 TargetPos
    {
        set { mTargetPos = value; }
    }

    bool isMove = false;

    public bool IsMove
    {
        set { isMove = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, mTargetPos, 15 * Time.deltaTime);
        }

        
    }
}
