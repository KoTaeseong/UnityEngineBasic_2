using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CUIPlayGame : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartGame()
    {
        gameManager.CreateDeck();
        
        this.transform.Find("btnStart").gameObject.SetActive(false);
        this.transform.Find("btnDraw").gameObject.SetActive(true);
    }

    public void OnClickDraw()
    {
        gameManager.DrawCard(5);
    }
}
