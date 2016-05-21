using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EndlessGameMaster : MonoBehaviour
{

    public List<Transform> platformsList;
    [Space(10)]
    public Transform playerTrans;
    Vector3 playerPos;

    public float spawnLimit;

    public float platformCheck;

    public float destroyLimit;

    float destroyNum;

    float spawnNum;


    //bool make;

    void Start()
    {
        playerPos = playerTrans.position;

        destroyNum = playerTrans.position.y - 1;
    }



    void Update()
    {
        PlatformMaintance();

    }

    void PlatformMaintance()
    {
        // float platCheck = playerTrans.position.y + platformCheck;

        foreach (GameObject plat in platformsList[0])
        {
            if (plat.transform.position.y < (playerTrans.position.y - destroyLimit))
            {
                print("Plat");

                Destroy(plat);
            }
        }

        SpawnPlatforms();
    }

    void SpawnPlatforms()
    {

        //Vector3 xPos;
        Vector3 yPos;

        if (playerTrans.position.y <= spawnLimit)
        {
            print("Less");

            spawnNum = 10;
        }

        yPos = new Vector3(playerTrans.position.x, playerTrans.position.y - 10, playerTrans.position.z);


        PlatformCreation(yPos);
    }

    void PlatformCreation(Vector3 platformPos)     // Instantiates the platforms
    {
        bool create = true;

       // float destroyNum = playerTrans.position.y - 1;

        if (playerTrans.position.y <= destroyNum)
        {
            print("For Each");

            create = false;
        }


        if (create)
        {
            print("Create");

            Instantiate(platformsList[0], platformPos, Quaternion.identity);
        }
    }



}