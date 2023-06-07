using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{

    public GameObject enemy;
    public GameObject playerBullet;
    public GameObject particleEffect;
    public GameObject bossBullet;

    GameObject[] enemy_arr;
    GameObject[] playerBullet_arr;
    GameObject[] particleEffect_arr;
    GameObject[] bossBullet_arr;

    GameObject[] obj_arr;

    void Start()
    {

        enemy_arr= new GameObject[30];
        playerBullet_arr = new GameObject[32];
        particleEffect_arr = new GameObject[32];
        bossBullet_arr = new GameObject[100];


        InitObj();

    }

    void InitObj()
    {

        for(int i =0; i<enemy_arr.Length; i++)
        {
            enemy_arr[i] = Instantiate(enemy);
            enemy_arr[i].SetActive(false);

        }

        for(int i=0; i<playerBullet_arr.Length; i++)
        {
            playerBullet_arr[i] = Instantiate(playerBullet);
            playerBullet_arr[i].SetActive(false);

        }

        for(int i=0; i < particleEffect_arr.Length; i++)
        {
            particleEffect_arr[i] = Instantiate(particleEffect);
            particleEffect_arr[i].SetActive(false);

        }

        for(int i =0; i<bossBullet_arr.Length; i++)
        {
            bossBullet_arr[i]= Instantiate(bossBullet);
            bossBullet_arr[i].SetActive(false);

        }

    }

    public GameObject SelectObj(string name)
    {

        switch (name)
        {
            case "Enemy":
                obj_arr = enemy_arr;
                break;

            case "PlayerBullet":
                obj_arr = playerBullet_arr;
                break;

            case "ParticleEffect":
                obj_arr = particleEffect_arr;
                break;

            case "BossBullet":
                obj_arr = bossBullet_arr;
                break;

        }


        for(int i =0; i<obj_arr.Length; i++)
        {

            if (!obj_arr[i].activeSelf)
            {
                obj_arr[i].SetActive(true);
                return obj_arr[i];
            }

        }

        return null;

    }


}
