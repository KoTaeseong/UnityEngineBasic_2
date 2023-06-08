using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CCameraHandler : MonoBehaviour
{
    [SerializeField] GameObject Player = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        this.transform.position = Player.transform.position + new Vector3(0,0,-10f);
    }
}
