using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EndlessGameMaster : MonoBehaviour
{

    public List<GameObject> platformsList;
    [Space(10)]
    public Transform playerTrans;
    Vector3 playerPos;

    float platfromsSpawnedUp;

    public float spawnLimit;
    public float platformCheck;
    public float destroyLimit;

    float destroyNum;

    float spawnNum;

    float spwNum;


    //bool make;

    void Start()
    {
        playerPos = playerTrans.position;

        destroyNum = playerPos.y -= destroyLimit;

        spwNum = playerPos.y;
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


        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Plat");
  
        foreach (GameObject plat in platforms)
        {
            if (plat.transform.position.y > playerTrans.position.y + 20)  // When to destroy platform
            {
               // print("Plat");
                Destroy(plat);
            }

        }

        //if (playerTrans.position.y <= destroyNum)
        //{

        //    bool change;
        //    change = true;

        //    if (change)
        //    {
        //        //print("Change");
        //        destroyNum -= 15;
        //        change = false;
        //    }
        //    // Destroy(plat);
        //}

        SpawnPlatforms();
    }

    void SpawnPlatforms()
    {

        //Vector3 xPos;
        Vector3 yPos;

        float spawnHeight = platfromsSpawnedUp;

        yPos = new Vector3(Random.Range(playerPos.x - 5, playerPos.x + 5), playerTrans.position.y - 15, playerPos.z);


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