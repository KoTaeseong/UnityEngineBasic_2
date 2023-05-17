using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CParticleMgr : MonoBehaviour
{
    public static Action<Vector2> action= null;

    [SerializeField] GameObject PFExplosion = null;
    [SerializeField] int num = 5;

    List<GameObject> explosionList= new List<GameObject>();

    int Index = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < num; i++)
        {
            GameObject t = Instantiate(PFExplosion);
            t.transform.SetParent(this.transform);
            t.SetActive(false);
            explosionList.Add(t);
        }

        action = DoExplosion;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DoExplosion(Vector2 tPos)
    {
        GameObject t = explosionList[Index];
        t.transform.position = tPos;
        t.SetActive(false);
        t.SetActive(true);

        Index++;
        if (Index == num)
        {
            Index= 0;
        }
    }
}
