using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCard : MonoBehaviour
{
    bool isHide = true;
    SpriteRenderer cardRenderer;

    Vector3 target_position;

    bool mMove = false;

    // Start is called before the first frame update
    void Start()
    {
        cardRenderer= this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //카드 앞 뒷면 표시
        if (isHide == true)
        {
            cardRenderer.color = new Color(0.3f,0.3f,0.3f,1f);
        }
        else
        {
            cardRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }

        if(mMove)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, target_position, 10 * Time.deltaTime);
        }
    }
}
