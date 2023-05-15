using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> PFEnemyList = null;
    [SerializeField] List<GameObject> PFObject = null;

    [SerializeField] List<GameObject> mStartPosList = null;
    [SerializeField] List<GameObject> mEndPosList = null;

    [SerializeField] float mCreateCycle = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
