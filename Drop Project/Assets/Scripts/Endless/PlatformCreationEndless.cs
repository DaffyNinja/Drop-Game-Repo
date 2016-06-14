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

    int platIndex;
    int platNum;


    //bool make;

    void Start()
    {
        playerPos = playerTrans.position;
    }

    void Update()
    {
        PlatformMaintance();

      //  platIndex = Mathf.RoundToInt(Random.Range(0, platformsList.Count));
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
        // Positions
        Vector3 pos = new Vector3(playerPos.x, playerTrans.position.y - 10, playerPos.z);
        Vector3 pos2 = new Vector3(playerPos.x, playerTrans.position.y - 35, playerPos.z);
        Vector3 pos3 = new Vector3(playerPos.x, playerTrans.position.y - 65, playerPos.z);

        PlatformCreation(pos, pos2, pos3);
    }



    void PlatformCreation(Vector3 platformPos1, Vector3 platformPos2, Vector3 platformPos3)     // Instantiates the platforms
    {
        bool create = true;

        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Plat");

        foreach (GameObject plat in platforms)         // Destroys Platforms
        {
            if (platformPos3.y < plat.transform.position.y)  // When 
            {
                create = false;
            }
        }

        if (create)
        {
            Instantiate(platformsList[Mathf.RoundToInt(Random.Range(0, platformsList.Count))], platformPos1, Quaternion.identity);
            Instantiate(platformsList[Mathf.RoundToInt(Random.Range(0, platformsList.Count))], platformPos2, Quaternion.identity);
            Instantiate(platformsList[Mathf.RoundToInt(Random.Range(0, platformsList.Count))], platformPos3, Quaternion.identity);
        }

    }



}