using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EndlessGameMaster : MonoBehaviour
{

    public List<Transform> platformsList;
    [Space(10)]
    public Transform playerTrans;
    Vector3 playerPos;

    public float yLimit;

    bool make;

    void Start()
    {
        playerPos = playerTrans.position;
    }



    void Update()
    {
        if (playerTrans.position.y <= playerPos.y - yLimit)
        {
            make = true;

            PlatformCreation();


            print("Below");

        }
        else
        {
            make = false;
        }

    }

    void PlatformCreation()
    {
        if (make == true)
        {
            Instantiate(platformsList[0], new Vector3(playerTrans.position.x, playerTrans.position.y - 45, playerTrans.position.z), Quaternion.identity);
        }

        make = false;
    }



}