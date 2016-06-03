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

    float newYNum;


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
        float platCheck = playerTrans.position.y + platformCheck;


        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Plat");

        foreach (GameObject plat in platforms)         // Destroys Platforms
        {
            if (plat.transform.position.y > playerTrans.position.y + 25)  // When to destroy platform
            {
                // print("Plat");
                Destroy(plat);
            }

        }

        SpawnPlatforms(platCheck);
    }

    void SpawnPlatforms(float upTo)
    {
        float spawnHeight = platfromsSpawnedUp;

        while (spawnHeight <= upTo)
        {
            //float x = Random.Range(-10.0f,10.0f);

            float YPos;
            Vector3 pos;

            int platformIndex;

            if (playerTrans.position.y < 800)
            {
                newYNum = 30;
            }
            else if (playerTrans.position.y > 800)
            {
                newYNum = 30;
            }

            if (playerTrans.position.y < 750)
            {
                newYNum = 30;
            }

            if (playerTrans.position.y < 700)
            {
                newYNum = 25;
            }

            if (playerTrans.position.y < 650)
            {
                newYNum = 20;
            }

            if (playerTrans.position.y < 600)
            {
                newYNum = 15;
            }

            if (playerTrans.position.y < 550)
            {
                newYNum = 10;
            }

            if (playerTrans.position.y < 500)
            {
                newYNum = 5;
            }


            YPos = Random.Range(playerTrans.transform.position.y - 5, playerTrans.transform.position.y - newYNum);

            pos = new Vector3(playerTrans.position.x, YPos,playerTrans.position.z);
            // posNeg = new Vector2(XNeg, playerTrans.transform.position.y - 50f);

            platformIndex = Mathf.RoundToInt(Random.Range(0, platformsList.Count));
            PlatformCreation(pos, platformIndex);

            spawnHeight += Random.Range(1, 50);

        }

        platfromsSpawnedUp = upTo;
    }



    //yPos = new Vector3(Random.Range(playerPos.x - 5, playerPos.x + 5), playerTrans.position.y - 12.5f, playerPos.z);

    //PlatformCreation(yPos);


    void PlatformCreation(Vector3 platformPos, int index)     // Instantiates the platforms
    {
        bool create = true;
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Plat");

        foreach (GameObject plat in platforms)         // Destroys Platforms
        {
            if (platformPos.y < plat.transform.position.y)  // When to destroy platform
            {
                create = false;
            }

        }

        if (create)
        {
            print("Create");

            Instantiate(platformsList[index], platformPos, Quaternion.identity);
        }

        // print(spwNum.ToString());

    }



}