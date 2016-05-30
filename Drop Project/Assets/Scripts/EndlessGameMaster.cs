using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EndlessGameMaster : MonoBehaviour
{

    public List<Transform> platformsList;
    [Space(10)]
    public Transform playerTrans;
    Vector3 playerPos;

    float platfromsSpawnedUp;

    public float spawnLimit;
    public float platformCheck;
    public float destroyLimit;

    float destroyNum;

    float spawnNum;

    float spwNum = 320;


    //bool make;

    void Start()
    {
        playerPos = playerTrans.position;

        destroyNum = playerPos.y -= destroyLimit;


    }



    void Update()
    {
        PlatformMaintance();


        // print(destroyNum.ToString());
        // print(playerPos.y - spawnLimit);

    }

    void PlatformMaintance()
    {
        // float platCheck = playerTrans.position.y + platformCheck;

        if (playerTrans.position.y <= destroyNum)
        {
            //foreach (GameObject plat in platformsList[0])
            //{
            //    // print("Destroy Plat");
            //    Destroy(plat);
            //}

            bool change;
            change = true;

            if (change)
            {
                //print("Change");
                destroyNum -= 15;
                change = false;
            }
            // Destroy(plat);
        }


        SpawnPlatforms();
    }

    void SpawnPlatforms()
    {

        //Vector3 xPos;
        Vector3 yPos;

        float spawnHeight = platfromsSpawnedUp;


        //if (playerTrans.position.y < playerTrans.position.y - 10)
        //{
        //    //print("Less");

        //    spawnNum = 10;
        //}

        yPos = new Vector3(playerPos.x - 2, playerTrans.position.y - 10, playerPos.z);


        PlatformCreation(yPos);
    }

    void PlatformCreation(Vector3 platformPos)     // Instantiates the platforms
    {
        bool create;

        if (playerTrans.position.y >= spwNum)
        {
           // print("Player UP");

            create = false;

            // spawnLimit += 10;
        }
        else
        {
           // print("Create");

            spwNum -= 20;

            create = true;

        }

        if (create)
        {
            Instantiate(platformsList[0], platformPos, Quaternion.identity);

           
        }

       // print(spwNum.ToString());

    }



}