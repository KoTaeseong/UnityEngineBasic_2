using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDeck : MonoBehaviour
{
    public List<string> mDeckCards = null;

    [SerializeField] public CCard PFCard = null;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            CCard tCard = Instantiate<CCard>(PFCard);
            tCard.transform.SetParent(transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateDeck()
    {
        mDeckCards.Clear();

        mDeckCards = new List<string>()
        {
                "a","A",    //1
                "b","B",    //2
                "c","C",    //3
                "d","D",    //4
                "e","E",    //5
                "f","F",    //6
                "g","G",    //7
                "h","H",    //8
                "i","I",    //9
                "j","J"    //10
        };

    }
}
