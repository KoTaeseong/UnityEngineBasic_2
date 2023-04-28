using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCard : MonoBehaviour
{
    bool isHide = true;
    SpriteRenderer cardRenderer;
    Sprite cardSprtie = null;

    // Start is called before the first frame update
    void Start()
    {
        cardRenderer= this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //ī�� �� �޸� ǥ��
        if (isHide == true)
        {
            cardRenderer.color = new Color(0.3f,0.3f,0.3f,1f);
        }
        else
        {
            cardRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
