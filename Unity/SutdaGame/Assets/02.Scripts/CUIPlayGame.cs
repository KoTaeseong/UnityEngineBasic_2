using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIPlayGame : MonoBehaviour
{
    [SerializeField] GameManager mGameManager = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoStart()
    {
        mGameManager.DoTableSetting();
    }

    public void DoDraw()
    {
        mGameManager.DoDrawCard();
    }

    public void DoBatting()
    {
        mGameManager.DoCheckJokbo();
        mGameManager.Batting();
    }
}
