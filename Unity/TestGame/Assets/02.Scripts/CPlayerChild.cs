using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerChild : MonoBehaviour
{

    CPlayer player;

    private void Awake()
    {
        player =GetComponentInParent<CPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            player.enemyList.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            player.enemyList.Remove(collision.gameObject);
        }
    }
}
