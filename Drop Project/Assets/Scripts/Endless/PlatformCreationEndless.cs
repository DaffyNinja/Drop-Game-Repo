using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformCreationEndless : MonoBehaviour
{

    public List<GameObject> platformsList;
    [Space(10)]
    public Transform playerTrans;
    Vector3 playerPos;

    float platfromsSpawnedUp;

    public float spawnLimit;
    public float platformCheck;
    public float destroyLimit;

    int platNum;


    //bool make;

    void Start()
    {
        playerPos = playerTrans.position;
    }

    void Update()
    {
        PlatformMaintance();
    }

    void PlatformMaintance()
    {
        float platCheck = playerTrans.position.y - platformCheck;

        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Plat");

        foreach (GameObject plat in platforms)         // destroys platforms
        {
            if (plat.transform.position.y > playerTrans.position.y + 40)  // when to destroy platform
            {
                // print("plat");
                Destroy(plat);
            }

        }

        SpawnPlatforms();
    }

    void SpawnPlatforms()  //(UpTo)
    {
        Vector3 pos = new Vector3(playerPos.x, playerTrans.position.y - 5, playerPos.z);
        Vector3 pos2 = new Vector3(playerPos.x, playerTrans.position.y - 35, playerPos.z);
        Vector3 pos3 = new Vector3(playerPos.x, playerTrans.position.y - 65, playerPos.z);

        int platIndex = Mathf.RoundToInt(Random.Range(0, platformsList.Count));

        PlatformCreation(pos,pos2,pos3, platIndex);

    }



    void PlatformCreation(Vector3 platformPos1, Vector3 platformPos2, Vector3 platformPos3, int index)     // Instantiates the platforms
    {
        bool create = true;
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Plat");

        foreach (GameObject plat in platforms)         // Destroys Platforms
        {
            if (platformPos3.y < plat.transform.position.y - 5)  // When 
            {
                create = false;
            }
        }


        if (create)
        {
            Instantiate(platformsList[index], platformPos1, Quaternion.identity);
            Instantiate(platformsList[index], platformPos2, Quaternion.identity);
            Instantiate(platformsList[index], platformPos3, Quaternion.identity);
        }

    }



}