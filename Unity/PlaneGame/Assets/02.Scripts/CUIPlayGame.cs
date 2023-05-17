using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIPlayGame : MonoBehaviour
{
    public static Action<int> action = null;

    [SerializeField] TMPro.TMP_Text score = null;

    int mScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        action = UpdateScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateScore(int tScore)
    {
        mScore += tScore;

        score.text = "SCORE : " + mScore.ToString();
    }
}
