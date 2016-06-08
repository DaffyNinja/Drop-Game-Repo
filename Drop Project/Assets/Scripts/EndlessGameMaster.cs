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
    }

    void PlatformMaintance()
    {
        float platCheck = playerTrans.position.y - platformCheck;

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

        platfromsSpawnedUp = upTo;
    }

    void PlatformCreation(Vector3 platformPos, int index)     // Instantiates the platforms
    {
        bool create = true;
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Plat");

        foreach (GameObject plat in platforms)         // Destroys Platforms
        {
            if (platformPos.y == plat.transform.position.y)  // When to destroy platform
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